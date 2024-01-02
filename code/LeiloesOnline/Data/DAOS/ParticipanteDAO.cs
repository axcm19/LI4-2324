using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;

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

        string s_cmd = "SELECT * FROM dbo.Participante WHERE cc = @cc";
        try
        {
            using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                {
                    cmd.Parameters.AddWithValue("@cc", cc);
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

        string s_cmd = "SELECT * FROM dbo.Participante WHERE nif = @nif";
        try
        {
            using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                {
                    cmd.Parameters.AddWithValue("@nif", nif);
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

        public Participante remove(string key)
        {
            Participante result = get(key);
            string s_cmd = "DELETE FROM dbo.Participante WHERE email_participante = " + key;
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
                throw new DAOException("Erro no remove do ParticipanteDAO");
            }
            return result;
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
    }
}
