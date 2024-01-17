using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;

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


        public List<Leilao> getAllLeiloes(string keyParticipante)
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


        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Leilao value)
        {
            string s_cmd = "INSERT INTO dbo.Leilao (id_leilao, categoria, nome, data_inicio, data_fim, preco_base, valor_minimo_licitacao, licitacao_atual, aprovado, fk_email_participante_propos) VALUES" +
                            "('" + value.id_leilao + "','" + value.categoria + "','" + value.nome + "','" + value.data_inicio + "','" + value.data_fim + "','" + value.preco_base
                            + "','" + value.valor_minimo_licitacao + "','" + value.licitacao_atual + "','" + value.aprovado + "','" + value.email_quem_propos + "')";
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

        
        
    }
}
