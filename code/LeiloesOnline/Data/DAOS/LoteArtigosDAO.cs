using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.Intrinsics.X86;

namespace LeiloesOnline.Data.DAOS
{
    internal class LoteArtigosDAO
    {
        private static LoteArtigosDAO? singleton = null;

        private LoteArtigosDAO() { }

        public static LoteArtigosDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new LoteArtigosDAO();
            }
            return singleton;
        }

        public bool containsKey(int keyLeilao)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Lote_Artigos WHERE fk_id_leilao = " + keyLeilao;
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
                throw new DAOException("Erro no containsKey do LoteArtigosDAO");
            }
            return result;
        
        }

        public bool containsValue(LoteArtigos value)
        {
            return containsKey(value.id_leilao);
        }

        public LoteArtigos get(int key)
        {
            /*
             tem de devolver a lista de todos os artigos do leilão
             */

            LoteArtigos? lote_art = new LoteArtigos();
            string s_cmd = $"SELECT fk_id_artigo FROM dbo.Lote_Artigos where fk_id_leilao = '{key}'";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<int> lista_id_artigo = con.Query<int>(s_cmd);

                    foreach (int ad in lista_id_artigo)
                    {
                        // buscar o artigo
                        Artigo art = ArtigoDAO.getInstance().get(ad);
                        lote_art.adicionaArtigoAoLote(art);
                    }
                }
                
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return lote_art;
        }

        public bool isEmpty()
        {
            return size() == 0;
        }
        
        public void put(LoteArtigos value)
        {

            /*
             para cada artigo na lista associa ao respetivo id do leilão
             */

            foreach(Artigo a in value.artigos)
            {
                string s_cmd = "INSERT INTO dbo.Lote_Artigos (fk_id_artigo, fk_id_leilao) VALUES" +
                                "('" + a.getIdArtigo() + "','" + value.id_leilao + "')";
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
                    throw new DAOException("Erro no put do LoteArtigosDAO");
                }

            }
        }

        public LoteArtigos remove(int key)
        {   
            /*
             remove todos os artigos associados à key de um leilão
             */

            LoteArtigos result = get(key);
            string s_cmd = "DELETE FROM dbo.Lote_Artigos WHERE fk_id_artigo = " + key;
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
            string s_cmd = "SELECT COUNT(*) FROM dbo.Lote_Artigos";
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
                throw new DAOException("Erro no size do LicitacaoDAO");
            }
            return result;
        }

        /*
         * Acho que não vale a pena implementar este metodo
        */
        /*
        public ICollection<LoteArtigos> values()
        {
            ICollection<LoteArtigos> result = new HashSet<LoteArtigos>();
            string s_cmd = "SELECT * FROM dbo.Lote_Artigos";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    IEnumerable<Artigo> aux = con.Query<Artigo>(s_cmd);
                    foreach (Artigo ad in aux)
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
        }*/

    }
}
