using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;

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

        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Utilizador WHERE id = " + key;
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
                throw new DAOException("Erro no containsKey do UtilizadorDAO");
            }
            return result;
        }
        /*
        public bool containsValue(Utilizador value)
        {
            return containsKey(value.getID());
        }

        public Utilizador get(int key)
        {
            return DAOAuxiliar.getUtilizador(key);
        }

        public bool isEmpty()
        {
            return size() == 0;
        }

        public ICollection<int> keys()
        {
            return DAOAuxiliar.getUtilizadoresIDs();
        }

        public void put(int key, Utilizador value)
        {
            string s_cmd = "INSERT INTO dbo.Utilizador (userType,nome,nif,cartao_cidadao,e_mail,rua_porta_andar,cidade,codigo_postal,apresentacao,aprovado,username,password_) VALUES" +
                            "('" + value.getUserType() + "','" + value.getNome() + "','" +
                            value.getNIF() + "','" + value.getCC() + "','" + value.getEmail() + "','" + value.getRuaPortaAndar() + "','" +
                            value.getCidade() + "','" + value.getCodigoPostal() + "','" + value.getApresentacao() + "','" +
                            (value.getAprovado() ? "1" : "0") + "','" + value.getUsername() + "','" + value.getPassword() + "')";
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
                throw new DAOException("Erro no put do UtilizadorDAO");
            }
        }

        public Utilizador remove(int key)
        {
            Utilizador result = get(key);
            string s_cmd = "DELETE FROM dbo.Utilizador WHERE id = " + key;
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
                throw new DAOException("Erro no remove do UtilizadorDAO");
            }
            return result;
        }

        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Utilizador";
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
                throw new DAOException("Erro no size do Utilizador");
            }
            return result;
        }

        public ICollection<Utilizador> values()
        {
            return DAOAuxiliar.getUtilizadores();
        }

        public bool existsEmail(string email)
        {
            return DAOAuxiliar.existsEmail(email);
        }

        public bool existsCC(string cc)
        {
            return DAOAuxiliar.existsCC(cc);
        }

        public bool existsNIF(string nif)
        {
            return DAOAuxiliar.existsNIF(nif);
        }

        public bool existsUsername(string username)
        {
            return DAOAuxiliar.existsUsername(username);
        }

        public Utilizador getUtilizadorByEmail(string email)
        {
            return DAOAuxiliar.getUtilizadorByEmail(email);
        }
        */
    }
}
