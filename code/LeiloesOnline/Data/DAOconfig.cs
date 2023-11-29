using System.Data.SqlClient;

namespace LeiloesOnline.Data
{
    /// <summary>
    /// Esta classe armazena os dados de acesso à base de dados.
    /// </summary>
    internal class DAOconfig
    {
        public static string GetConnectionString()
        {
            return "Server = LAPTOP-CTF72MOG; Initial Catalog = LI4; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        }
    }
}
