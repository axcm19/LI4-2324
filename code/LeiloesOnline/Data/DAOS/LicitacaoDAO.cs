using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Drawing;

namespace LeiloesOnline.Data.DAOS
{
    internal class LicitacaoDAO
    {
        private static LicitacaoDAO? singleton = null;

        private LicitacaoDAO() { }

        public static LicitacaoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new LicitacaoDAO();
            }
            return singleton;
        }

        public bool containsKeys(string keyParticipante, int keyLeilao)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Licitacao WHERE fk_email_participante = " + keyParticipante + "AND fk_id_leilao = " + keyLeilao;
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
                throw new DAOException("Erro no containsKey do LicitacaoDAO");
            }
            return result;
        }

        
        public bool containsValue(Licitacao value)
        {
            return containsKeys(value.email_participante, value.id_leilao);
        }
        

        public Licitacao get(string keyParticipante, int keyLeilao)
        {
            Licitacao? li = null;
            string s_cmd = "SELECT * FROM dbo.Licitacao WHERE fk_email_participante = " + keyParticipante + "AND fk_id_leilao = " + keyLeilao;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DateTime data_ocorreu;
                            float valor = 0;
                            string fk_email_participante;
                            int fk_id_leilao = 0;

                            while (reader.Read())
                            {
                                data_ocorreu = reader.GetDateTime(reader.GetOrdinal("data_ocorreu"));
                                valor = (float)reader.GetDouble(reader.GetOrdinal("valor"));
                                fk_email_participante = reader.GetString(reader.GetOrdinal("fk_email_participante"));
                                fk_id_leilao = reader.GetInt32(reader.GetOrdinal("fk_id_leilao"));

                                Licitacao aux = new Licitacao(data_ocorreu, valor, fk_email_participante, fk_id_leilao);
                                li = aux;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return li;
        }

        public Dictionary<int, Licitacao> getAllLicitacoes(int id_leilao, string keyParticipante)
        {

            Dictionary<int, Licitacao> licitacoes = new Dictionary<int, Licitacao>();

            if (id_leilao == 0 && !keyParticipante.Equals(""))
            {

                string s_cmd = "SELECT * FROM dbo.Licitacao WHERE fk_email_participante = " + keyParticipante;
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DateTime data_ocorreu;
                                float valor = 0;
                                string fk_email_participante;
                                int fk_id_leilao = 0;

                                while (reader.Read())
                                {
                                    data_ocorreu = reader.GetDateTime(reader.GetOrdinal("data_ocorreu"));
                                    valor = (float)reader.GetDouble(reader.GetOrdinal("valor"));
                                    fk_email_participante = reader.GetString(reader.GetOrdinal("fk_email_participante"));
                                    fk_id_leilao = reader.GetInt32(reader.GetOrdinal("fk_id_leilao"));

                                    Licitacao aux = new Licitacao(data_ocorreu, valor, fk_email_participante, fk_id_leilao);
                                    licitacoes.Add(aux.id_leilao, aux);
                                }
                            }
                        }
                    }

                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Licitacao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
            }
            if (id_leilao != 0 && keyParticipante.Equals(""))
            {

                string s_cmd = "SELECT * FROM dbo.Licitacao WHERE fk_id_leilao = " + id_leilao;
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                DateTime data_ocorreu;
                                float valor = 0;
                                string fk_email_participante;
                                int fk_id_leilao = 0;

                                while (reader.Read())
                                {
                                    data_ocorreu = reader.GetDateTime(reader.GetOrdinal("data_ocorreu"));
                                    valor = (float)reader.GetDouble(reader.GetOrdinal("valor"));
                                    fk_email_participante = reader.GetString(reader.GetOrdinal("fk_email_participante"));
                                    fk_id_leilao = reader.GetInt32(reader.GetOrdinal("fk_id_leilao"));

                                    Licitacao aux = new Licitacao(data_ocorreu, valor, fk_email_participante, fk_id_leilao);
                                    licitacoes.Add(aux.id_leilao, aux);
                                }
                            }
                        }
                    }

                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Licitacao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
            }
            return licitacoes;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Licitacao value)
        {

            //inverter formato das datas porque o SQL é esquisito para caralho!
            string inverted_data_ocorreu = value.data_ocorreu.ToString("yyyy/MM/dd HH:mm:ss");

            string s_cmd = "INSERT INTO dbo.Licitacao (data_ocorreu, valor, fk_email_participante, fk_id_leilao) VALUES" +
                            "('" + inverted_data_ocorreu + "','" + value.valor + "','" + value.email_participante + "','" + value.id_leilao + "')";

            string s_cmd_2 = "UPDATE dbo.Leilao SET licitacao_atual = " + value.valor + " WHERE id_leilao =" + value.id_leilao;

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
                    using (SqlCommand cmd = new SqlCommand(s_cmd_2, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine("Licitação atual atualizada com sucesso");
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no put do LicitacaoDAO");
            }
        }

        public Licitacao remove(string keyParticipante, int keyLeilao)
        {
            Licitacao result = get(keyParticipante, keyLeilao);
            string s_cmd = "DELETE FROM dbo.Licitacao WHERE fk_email_participante = " + keyParticipante + "AND fk_id_leilao = " + keyLeilao;
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
                throw new DAOException("Erro no remove do LicitacaoDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Licitacao";
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
                throw new DAOException("Erro no size do Licitacao");
            }
            return result;
        }

        public ICollection<Licitacao> values()
        {
            ICollection<Licitacao> result = new HashSet<Licitacao>();
            string s_cmd = "SELECT * FROM dbo.Licitacao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Licitacao> aux = con.Query<Licitacao>(s_cmd);
                    foreach (Licitacao ad in aux)
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
