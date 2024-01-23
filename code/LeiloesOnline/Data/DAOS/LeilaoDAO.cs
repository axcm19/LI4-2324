using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using System.Globalization;
using System;

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
            string s_cmd = "SELECT * FROM dbo.Leilao where id_leilao = " + key;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int id_leilao = 0;
                            string categoria;
                            string nome;
                            DateTime data_inicio;
                            DateTime data_fim;
                            float preco_base = 0;
                            float valor_minimo_licitacao = 0;
                            float licitacao_atual = 0;
                            bool aprovado;
                            string fk_email_participante_propos;

                            List<Licitacao> licitacoes = new List<Licitacao>();
                            LoteArtigos lote_artigos = new LoteArtigos();


                            while (reader.Read())
                            {
                                id_leilao = reader.GetInt32(reader.GetOrdinal("id_leilao"));
                                categoria = reader.GetString(reader.GetOrdinal("categoria"));
                                nome = reader.GetString(reader.GetOrdinal("nome"));
                                data_inicio = reader.GetDateTime(reader.GetOrdinal("data_inicio"));
                                data_fim = reader.GetDateTime(reader.GetOrdinal("data_fim"));
                                preco_base = (float)reader.GetDouble(reader.GetOrdinal("preco_base"));
                                valor_minimo_licitacao = (float)reader.GetDouble(reader.GetOrdinal("valor_minimo_licitacao"));
                                licitacao_atual = (float)reader.GetDouble(reader.GetOrdinal("licitacao_atual"));
                                aprovado = reader.GetBoolean(reader.GetOrdinal("aprovado"));
                                fk_email_participante_propos = reader.GetString(reader.GetOrdinal("fk_email_participante_propos"));

                                licitacoes = LicitacaoDAO.getInstance().getAllLicitacoes(id_leilao, "");
                                lote_artigos.artigos = getArtigos(id_leilao);


                                Leilao aux = new Leilao(id_leilao, categoria, nome, data_inicio, data_fim, preco_base, valor_minimo_licitacao, licitacao_atual, aprovado, fk_email_participante_propos, licitacoes, lote_artigos);
                                leilao = aux;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return leilao;
        }


        public Dictionary<int, Leilao> getAllLeiloesParticipante(string keyParticipante)
        {
            Dictionary<int, Leilao> leiloes = new Dictionary<int, Leilao>();

            string s_cmd = "SELECT * FROM dbo.Leilao WHERE fk_email_participante_propos = " + keyParticipante;
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();
                    Leilao aux = con.QueryFirst<Leilao>(s_cmd);
                    leiloes.Add(aux.id_leilao, aux);
                    
                }
                
            }
            catch (InvalidOperationException)
            {
                // Captura a exceção quando não há resultados e retorna um dicionário vazio
                return new Dictionary<int, Leilao>();
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return leiloes;
        }

        public Dictionary<int, Leilao> getAllLeiloesAprovados(string criterioDeOrdenacao, string categoria)
        {
            Dictionary<int, Leilao> result = new Dictionary<int, Leilao>();

            // criterio e categoria podem ser opcionais
            if (categoria.Equals("") && criterioDeOrdenacao.Equals(""))
            {
                // ir buscar todos os leiloes
                string s_cmd = "SELECT * FROM dbo.Leilao where aprovado = 1";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();

                        IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                        // Itera sobre a coleção e adiciona ao dicionário
                        foreach (Leilao leilao in leiloes)
                        {
                            result.Add(leilao.id_leilao, leilao);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Leilao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            if(categoria.Equals("joias") && criterioDeOrdenacao.Equals(""))
            {
                // ir buscar todos os leiloes de joias
                string s_cmd = "SELECT * FROM dbo.Leilao where aprovado = 1 AND categoria = 'Joias'";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();

                        IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                        // Itera sobre a coleção e adiciona ao dicionário
                        foreach (Leilao leilao in leiloes)
                        {
                            result.Add(leilao.id_leilao, leilao);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Leilao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            if (categoria.Equals("quadros") && criterioDeOrdenacao.Equals(""))
            {
                // ir buscar todos os leiloes de quadros
                string s_cmd = "SELECT * FROM dbo.Leilao where aprovado = 1 AND categoria = 'Quadros'";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();

                        IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                        // Itera sobre a coleção e adiciona ao dicionário
                        foreach (Leilao leilao in leiloes)
                        {
                            result.Add(leilao.id_leilao, leilao);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Leilao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            if (categoria.Equals("livros") && criterioDeOrdenacao.Equals(""))
            {
                // ir buscar todos os leiloes de livros
                string s_cmd = "SELECT * FROM dbo.Leilao where aprovado = 1 AND categoria = 'Livros'";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();

                        IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                        // Itera sobre a coleção e adiciona ao dicionário
                        foreach (Leilao leilao in leiloes)
                        {
                            result.Add(leilao.id_leilao, leilao);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Leilao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            if (categoria.Equals("misto") && criterioDeOrdenacao.Equals(""))
            {
                // ir buscar todos os leiloes de livros mistos
                string s_cmd = "SELECT * FROM dbo.Leilao where aprovado = 1 AND categoria = 'Misto'";
                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        con.Open();

                        IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                        // Itera sobre a coleção e adiciona ao dicionário
                        foreach (Leilao leilao in leiloes)
                        {
                            result.Add(leilao.id_leilao, leilao);
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    // Captura a exceção quando não há resultados e retorna um dicionário vazio
                    return new Dictionary<int, Leilao>();
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
                return result;
            }
            return result;
        }

        public Dictionary<int, Leilao> getAllLeiloes()
        {
            Dictionary<int, Leilao> result = new Dictionary<int, Leilao>();

            // ir buscar todos os leiloes
            string s_cmd = "SELECT * FROM dbo.Leilao";
            try
            {
                using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                {
                    con.Open();

                    IEnumerable<Leilao> leiloes = con.Query<Leilao>(s_cmd);

                    // Itera sobre a coleção e adiciona ao dicionário
                    foreach (Leilao leilao in leiloes)
                    {
                        result.Add(leilao.id_leilao, leilao);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                // Captura a exceção quando não há resultados e retorna um dicionário vazio
                return new Dictionary<int, Leilao>();
            }
            catch (Exception e)
            {
                throw new DAOException(e.Message);
            }
            return result;
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

                        string s_cmd_2 = "INSERT INTO dbo.Lote_Artigos(fk_id_artigo, fk_id_leilao) VALUES" +
                           "('" + a.getIdArtigo() + "','" + value.id_leilao + "')";

                        Console.WriteLine(s_cmd_2);


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

        public void remove(int key)
        {
            string s_cmd_1 = "DELETE FROM dbo.Licitacao WHERE fk_id_leilao = " + key;
            string s_cmd_2 = "DELETE FROM dbo.Lote_Artigos WHERE fk_id_leilao = " + key;
            string s_cmd_3 = "DELETE FROM dbo.Leilao WHERE id_leilao = " + key;
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
                }
            }
            catch (Exception)
            {
                throw new DAOException("Erro no remove do LeilaoDAO");
            }
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


        public bool aprovar(int key, int valor)
        {
            bool result = false;
            string s_cmd = "UPDATE dbo.Leilao SET aprovado = " + valor + " WHERE id_leilao = " + key;
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


        public List<Artigo> getArtigos(int key)
        {
            List<Artigo> artigos = new List<Artigo>();

            string s_cmd = "SELECT * FROM dbo.Lote_Artigos where fk_id_leilao = " + key;
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
                                id_artigo = reader.GetInt32(reader.GetOrdinal("fk_id_artigo"));
                                Artigo a = ArtigoDAO.getInstance().get(id_artigo);
                                artigos.Add(a);
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



    }
}
