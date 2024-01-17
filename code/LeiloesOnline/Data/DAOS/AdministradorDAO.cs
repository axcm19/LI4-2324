using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;

namespace LeiloesOnline.Data.DAOS
{
    internal class AdministradorDAO
    {
        private static AdministradorDAO? singleton = null;

        private AdministradorDAO() { }

        public static AdministradorDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new AdministradorDAO();
            }
            return singleton;
        }

        public bool containsKey(string key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Administrador WHERE email_administrador = " + key;
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
                throw new DAOException("Erro no containsKey do AdministradorDAO");
            }
            return result;
        }
        
        public bool containsValue(Administrador value)
        {
            return containsKey(value.email_administrador);
        }

        public Administrador get(string key)
        {
            Administrador? admi = null;
            string s_cmd = "SELECT * FROM dbo.Administrador where email_administrador = " + key;

            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Administrador aux = con.QueryFirst<Administrador>(s_cmd);
                    admi = aux;
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return admi;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }


        public void put(Administrador value)
        {
            string s_cmd = "INSERT INTO dbo.Administrador (email_administrador, username, admi_password) VALUES" +
                            "('" + value.email_administrador + "','" + value.email_administrador + "','" +
                            value.email_administrador + "')";
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
                throw new DAOException("Erro no put do AdministradorDAO");
            }
        }

        public Administrador remove(string key)
        {
            Administrador result = get(key);
            string s_cmd = "DELETE FROM dbo.Administrador WHERE email_administrador = " + key;
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
                throw new DAOException("Erro no remove do AdministradorDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Administrador";
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
                throw new DAOException("Erro no size do Administrador");
            }
            return result;
        }

        public ICollection<Administrador> values()
        {
            ICollection<Administrador> result = new HashSet<Administrador>();
            string s_cmd = "SELECT * FROM dbo.Administrador";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Administrador> aux = con.Query<Administrador>(s_cmd);
                    foreach (Administrador ad in aux)
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
