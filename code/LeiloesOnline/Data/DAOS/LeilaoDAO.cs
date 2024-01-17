using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using System.Globalization;

namespace LeiloesOnline.Data.DAOS
{
    internal class LeilaoDAO
    {
        private static LeilaoDAO? singleton = null;

        private LeilaoDAO() { }

        public static LeilaoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new LeilaoDAO();
            }
            return singleton;
        }

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Leilao WHERE id_leilao = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no containsKey do LeilaoDAO");
            }
            return result;
        }
        
        public bool containsValue(Leilao value)
        {
            return containsKey(value.id_leilao);
        }

        public Leilao get(int key)
        {
            Leilao? leilao = null;
            string s_cmd = $"SELECT * FROM dbo.Leilao where id_leilao = '{key}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Leilao aux = con.QueryFirst<Leilao>(s_cmd);
                    leilao = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return leilao;
        }


        public List<Leilao> getAllLeiloesParticipante(string keyParticipante)
        {
            List<Leilao> leiloes = new List<Leilao>();

            string s_cmd = "SELECT * FROM dbo.Leilao WHERE fk_email_participante_propos = " + keyParticipante;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Leilao aux = con.QueryFirst<Leilao>(s_cmd);
                    leiloes.Add(aux);
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return leiloes;
        }

        public List<Leilao> getAllLeiloes(string criterioDeOrdenacao, string categoria)
        {
            List<Leilao> result = new List<Leilao>();

            // criterio e categoria podem ser opcionais
            if (criterioDeOrdenacao.Equals("") && categoria.Equals(""))
            {
                string s_cmd = "SELECT * FROM dbo.Leilao WHERE aprovado = 0";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();
                        Leilao aux = con.QueryFirst<Leilao>(s_cmd);
                        result.Add(aux);

                        if(result.Count == 0)
                        {
                            return new List<Leilao>();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            else
            {
                Console.WriteLine("ainda não está implementado");
                return result;
            }
            
        }


        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Leilao value)
        {

            //inverter formato das datas porque o SQL é esquisito para caralho!
            string inverted_data_inicio = value.data_inicio.ToString("yyyy/MM/dd HH:mm:ss");
            string inverted_data_fim = value.data_fim.ToString("yyyy/MM/dd HH:mm:ss");


            string s_cmd = "INSERT INTO dbo.Leilao (id_leilao, categoria, nome, data_inicio, data_fim, preco_base, valor_minimo_licitacao, licitacao_atual, aprovado, fk_email_participante_propos) VALUES" +
                            "('" + value.id_leilao + "','" + value.categoria + "','" + value.nome + "','" + inverted_data_inicio + "','" + inverted_data_fim + "','" + value.preco_base
                            + "','" + value.valor_minimo_licitacao + "','" + value.licitacao_atual + "','" + value.aprovado + "','" + value.email_quem_propos + "')";

            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    foreach(Artigo a in value.lote_artigos.artigos)
                    {
                        Console.WriteLine(a.getIdArtigo());
                        Console.WriteLine(value.id_leilao);

                        string s_cmd_2 = "INSERT INTO dbo.LoteLote_Artigos(fk_id_artigo, fk_id_leilao) VALUES" +
                           "('" + a.getIdArtigo() + "','" + value.id_leilao + "')";


                        using (SqlCommand cmd = new SqlCommand(s_cmd_2, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do LeilaoDAO");
            }
        }

        public Leilao remove(int key)
        {
            Leilao result = get(key);
            string s_cmd = "DELETE FROM dbo.Leilao WHERE id_leilao = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no remove do LeilaoDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no size do Leilao");
            }
            return result;
        }

        public ICollection<Leilao> values()
        {
            ICollection<Leilao> result = new HashSet<Leilao>();
            string s_cmd = "SELECT * FROM dbo.Leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Leilao> aux = con.Query<Leilao>(s_cmd);
                    foreach (Leilao ad in aux)
                    {
                        result.Add(ad);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }

        public bool aprovar(int key)
        {
            bool result = false;
            string s_cmd = "UPDATE dbo.Leilao SET aprovado = '1' WHERE id_leilao = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no aprovar do LeilaoDAO");
            }
            return result;
        }



    }
}
