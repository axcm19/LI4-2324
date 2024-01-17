using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;

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
                    Licitacao aux = con.QueryFirst<Licitacao>(s_cmd);
                    li = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return li;
        }

        public List<Licitacao> getAllLicitacoes(string keyParticipante)
        {
            List<Licitacao> licitacoes = new List<Licitacao>();

            string s_cmd = "SELECT * FROM dbo.Licitacao WHERE fk_email_participante = " + keyParticipante;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Licitacao aux = con.QueryFirst<Licitacao>(s_cmd);
                    licitacoes.Add(aux);
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return licitacoes;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Licitacao value)
        {
            string s_cmd = "INSERT INTO dbo.Licitacao (data_ocorreu, valor, fk_email_participante, fk_id_leilao) VALUES" +
                            "('" + value.data_ocorreu + "','" + value.valor + "','" + value.email_participante + "','" + value.id_leilao + "')";
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
