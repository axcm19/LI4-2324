using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace LeiloesOnline.Data.DAOS
{
    internal class ParticipanteDAO
    {
        private static ParticipanteDAO? singleton = null;

        private ParticipanteDAO() { }

        public static ParticipanteDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new ParticipanteDAO();
            }
            return singleton;
        }

        public bool containsKey(string key)
        {
            bool result = false;

            string s_cmd = "SELECT * FROM dbo.Participante WHERE email_participante = " + key;
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
                throw new DAOException("Erro no containsKey do ParticipanteDAO");
            }
            return result;
        }

        public bool existsCC(string cc)
        {
            bool result = false;

        string s_cmd = "SELECT * FROM dbo.Participante WHERE cc = " + cc;
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
            throw new DAOException("Erro no existsCC do ParticipanteDAO");
        }
        return result;
    }

    public bool existsNIF(string nif)
    {
        bool result = false;

        string s_cmd = "SELECT * FROM dbo.Participante WHERE nif = " + nif;
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
            throw new DAOException("Erro no existsNIF do ParticipanteDAO");
        }
        return result;
    }
        
        public bool containsValue(Participante value)
        {
            return containsKey(value.email_participante);
        }

        public Participante get(string key)
        {
            Participante? participante = null;
            string s_cmd = "SELECT * FROM dbo.Participante where email_participante = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Participante aux = con.QueryFirst<Participante>(s_cmd);
                    participante = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return participante;
        }

        public Dictionary<int, Artigo> getArtigos(string key)
        {
            Dictionary<int, Artigo> artigos = new Dictionary<int, Artigo>();

            string s_cmd = "SELECT * FROM dbo.Artigo where fk_email_participante_dono =" + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int id_artigo = 0;

                            while (reader.Read())
                            {
                                id_artigo = reader.GetInt32(reader.GetOrdinal("id_artigo"));
                                Artigo a = ArtigoDAO.getInstance().get(id_artigo);
                                artigos.Add(id_artigo, a);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return artigos;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Participante value)
        {
            string s_cmd = "INSERT INTO dbo.Participante (email_participante, username, morada, carteira, user_password, cc, nif) VALUES" +
                            "('" + value.email_participante + "','" + value.username + "','" +
                            value.morada + "','" + value.carteira + "','" + value.user_password + "','" +
                            value.cc + "','" + value.nif + "')";
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
                throw new DAOException("Erro no put do ParticipanteDAO");
            }
        }

        public void remove(string key)
        {
            string s_cmd_1 = "DELETE FROM dbo.Licitacao WHERE fk_email_participante = " + key;

            string s_cmd_2 = "DELETE FROM dbo.Artigo WHERE fk_email_participante_dono = " + key;

            string s_cmd_3 = "DELETE FROM dbo.Leilao WHERE fk_email_participante_propos = " + key;

            string s_cmd_4 = "DELETE FROM dbo.Participante WHERE email_participante = " + key;

            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(s_cmd_1, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(s_cmd_2, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(s_cmd_3, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand(s_cmd_4, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no remove do ParticipanteDAO");
            }
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Participante";
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
                throw new DAOException("Erro no size do Participante");
            }
            return result;
        }

        public ICollection<Participante> values()
        {
            ICollection<Participante> result = new HashSet<Participante>();
            string s_cmd = "SELECT * FROM dbo.Participante";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Participante> aux = con.Query<Participante>(s_cmd);
                    foreach (Participante par in aux)
                    {
                        result.Add(par);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
        }


        public bool carregaSaldo(string key, float valor)
        {
            bool result = false;
            string s_cmd = "UPDATE dbo.Participante SET carteira = " +valor+ " WHERE email_participante = " + key;
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
                throw new DAOException("Erro ao carregar saldo do ParticipanteDAO");
            }
            return result;
        }
    }
}
