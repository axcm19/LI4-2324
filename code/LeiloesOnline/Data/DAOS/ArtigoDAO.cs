using LeiloesOnline.Business.Objects;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Drawing;
using Microsoft.VisualBasic;

namespace LeiloesOnline.Data.DAOS
{
    internal class ArtigoDAO
    {
        private static ArtigoDAO? singleton = null;

        private ArtigoDAO() { }


        //##########################################################################################################################################################################

        public static ArtigoDAO getInstance()
        {
            if (singleton == null)
            {
                singleton = new ArtigoDAO();
            }
            return singleton;
        }


        //##########################################################################################################################################################################


        public bool containsKey(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Artigo WHERE id_artigo = " + key;
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
                throw new DAOException("Erro no containsKey do ArtigoDAO");
            }
            return result;
        }


        //##########################################################################################################################################################################


        public bool containsKeyJoia(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Joia WHERE id_artigo = " + key;
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
                throw new DAOException("Erro no containsKey do ArtigoDAO");
            }
            return result;
        }


        //##########################################################################################################################################################################


        public bool containsKeyLivro(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Livro WHERE id_artigo = " + key;
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
                throw new DAOException("Erro no containsKey do ArtigoDAO");
            }
            return result;
        }


        //##########################################################################################################################################################################


        public bool containsKeyQuadro(int key)
        {
            bool result = false;
            string s_cmd = "SELECT * FROM dbo.Quadro WHERE id_artigo = " + key;
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
                throw new DAOException("Erro no containsKey do ArtigoDAO");
            }
            return result;
        }


        //##########################################################################################################################################################################


        public bool containsValue(Artigo value)
        {
            return containsKey(value.getIdArtigo());
        }


        //##########################################################################################################################################################################


        public Artigo get(int key)
        {
            Artigo? art = null;

            if(containsKeyQuadro(key) == true)
            {
                string s_cmd = "SELECT Artigo.id_artigo, nome, descricao, comprovativo,fk_email_participante_dono,titulo,nome_autor,ano,dimensoes  FROM Artigo, Quadro WHERE Artigo.id_artigo = " + key;
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
                                string nome;
                                string descricao;
                                string comprovativo;
                                string fk_email_participante_dono;
                                string titulo;
                                string nome_autor;
                                int ano = 0;
                                string dimensoes;

                                while (reader.Read())
                                {
                                    id_artigo = reader.GetInt32(reader.GetOrdinal("id_artigo"));
                                    nome = reader.GetString(reader.GetOrdinal("nome"));
                                    descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                    comprovativo = reader.GetString(reader.GetOrdinal("comprovativo"));
                                    fk_email_participante_dono = reader.GetString(reader.GetOrdinal("fk_email_participante_dono"));
                                    titulo = reader.GetString(reader.GetOrdinal("titulo"));
                                    nome_autor = reader.GetString(reader.GetOrdinal("nome_autor"));
                                    ano = reader.GetInt32(reader.GetOrdinal("ano"));
                                    dimensoes = reader.GetString(reader.GetOrdinal("dimensoes"));

                                    Quadro aux = new Quadro(id_artigo, nome, descricao, comprovativo, fk_email_participante_dono, titulo, nome_autor, ano, dimensoes);
                                    art = aux;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
            }

            if (containsKeyLivro(key) == true)
            {
                string s_cmd = $"SELECT Artigo.id_artigo, nome, descricao, comprovativo,fk_email_participante_dono, titulo, nome_autor, ano_edicao, editora, numero_paginas FROM Artigo, Livro WHERE Artigo.id_artigo = {key}";
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
                                string nome;
                                string descricao;
                                string comprovativo;
                                string fk_email_participante_dono;
                                string titulo;
                                string nome_autor;
                                int ano_edicao = 0;
                                string editora;
                                int numero_paginas = 0;

                                while (reader.Read())
                                {
                                    id_artigo = reader.GetInt32(reader.GetOrdinal("id_artigo"));
                                    nome = reader.GetString(reader.GetOrdinal("nome"));
                                    descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                    comprovativo = reader.GetString(reader.GetOrdinal("comprovativo"));
                                    fk_email_participante_dono = reader.GetString(reader.GetOrdinal("fk_email_participante_dono"));
                                    titulo = reader.GetString(reader.GetOrdinal("titulo"));
                                    nome_autor = reader.GetString(reader.GetOrdinal("nome_autor"));
                                    ano_edicao = reader.GetInt32(reader.GetOrdinal("ano_edicao"));
                                    editora = reader.GetString(reader.GetOrdinal("editora"));
                                    numero_paginas = reader.GetInt32(reader.GetOrdinal("numero_paginas"));

                                    Livro aux = new Livro(id_artigo, nome, descricao, comprovativo, fk_email_participante_dono, titulo, nome_autor, ano_edicao, editora, numero_paginas);
                                    art = aux;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
            }

            if (containsKeyJoia(key) == true)
            {
                string s_cmd = $"SELECT Artigo.id_artigo, nome, descricao, comprovativo,fk_email_participante_dono,material,tipo,pureza_material FROM Artigo, Joia WHERE Artigo.id_artigo = {key}";
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
                                string nome;
                                string descricao;
                                string comprovativo;
                                string fk_email_participante_dono;
                                string material;
                                string tipo;
                                float pureza_material = 0;


                                while (reader.Read())
                                {
                                    id_artigo = reader.GetInt32(reader.GetOrdinal("id_artigo"));
                                    nome = reader.GetString(reader.GetOrdinal("nome"));
                                    descricao = reader.GetString(reader.GetOrdinal("descricao"));
                                    comprovativo = reader.GetString(reader.GetOrdinal("comprovativo"));
                                    fk_email_participante_dono = reader.GetString(reader.GetOrdinal("fk_email_participante_dono"));
                                    material = reader.GetString(reader.GetOrdinal("material"));
                                    tipo = reader.GetString(reader.GetOrdinal("tipo"));
                                    pureza_material = (float)reader.GetDouble(reader.GetOrdinal("pureza_material"));

                                    Joia aux = new Joia(id_artigo, nome, descricao, comprovativo, fk_email_participante_dono, material, tipo, pureza_material);
                                    art = aux;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new DAOException(e.Message);
                }
            }
            return art;
        }


        //##########################################################################################################################################################################


        public bool isEmpty()
        {
            return size() == 0;
        }


        //##########################################################################################################################################################################


        public void put(Artigo value)
        {   

            if (value is Quadro)
            {
                Quadro value_aux = (Quadro) value; 
                //insere na tabela do artigo

                string s_cmd = "INSERT INTO dbo.Artigo (id_artigo, nome, descricao, comprovativo, is_livro, is_joia, is_quadro, fk_email_participante_dono) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.getNome() + "','" +
                                value_aux.getDescricao() + "','" + value_aux.getComprovativo() + "','"
                                + 0 + "','" + 0 + "','" + 1 +
                                "','" + value_aux.getEmail() + "')";

                // inserir na tabela de quadros
                string s_cmd_aux = "INSERT INTO dbo.Quadro (id_Artigo, titulo, nome_autor, ano, dimensoes) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.titulo + "','" +
                                value_aux.nome_autor + "','" + value_aux.ano +
                                "','" + value_aux.dimensoes + "')";

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
                        using (SqlCommand cmd2 = new SqlCommand(s_cmd_aux, con))
                        {
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no put do ArtigoDAO - Quadro");
                }

            }


            if (value is Joia)
            {
                Joia value_aux = (Joia)value;
                //insere na tabela do artigo

                string s_cmd = "INSERT INTO dbo.Artigo (id_artigo, nome, descricao, comprovativo, is_livro, is_joia, is_quadro, fk_email_participante_dono) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.getNome() + "','" +
                                value_aux.getDescricao() + "','" + value_aux.getComprovativo() + "','"
                                + 0 + "','" + 1 + "','" + 0 +
                                "','" + value_aux.getEmail() + "')";

                // inserir na tabela de joias
                string s_cmd_aux = "INSERT INTO dbo.Joia (id_Artigo, material, tipo, pureza_material) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.material + "','" +
                                value_aux.tipo +
                                "','" + value_aux.pureza_material + "')";
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
                        using (SqlCommand cmd2 = new SqlCommand(s_cmd_aux, con))
                        {
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();    
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no put do ArtigoDAO - Joia");
                }

            }


            if (value is Livro)
            {
                Livro value_aux = (Livro)value;
                //insere na tabela do artigo

                string s_cmd = "INSERT INTO dbo.Artigo (id_artigo, nome, descricao, comprovativo, is_livro, is_joia, is_quadro, fk_email_participante_dono) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.getNome() + "','" +
                                value_aux.getDescricao() + "','" + value_aux.getComprovativo() + "','"
                                + 1 + "','" + 0 + "','" + 0 +
                                "','" + value_aux.getEmail() + "')";

                // inserir na tabela de livros
                string s_cmd_aux = "INSERT INTO dbo.Livro (id_Artigo,  titulo, nome_autor, ano_edicao, editora, numero_paginas) VALUES" +
                                "('" + value_aux.getIdArtigo() + "','" + value_aux.titulo + "','" + value_aux.nome_autor + "','" +
                                value_aux.ano_edicao + "','" + value_aux.editora + "','" + value_aux.numero_paginas + "')";
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
                        using (SqlCommand cmd2 = new SqlCommand(s_cmd_aux, con))
                        {
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();    
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no put do ArtigoDAO - Livro");
                }

            }

        }


        //##########################################################################################################################################################################


        public Artigo remove(int key)
        {
            Artigo result = null;
            if (containsKey(key) && containsKeyQuadro(key))
            {

                //remove da tabela do artigo
                result = get(key);

                string s_cmd = "DELETE FROM dbo.Artigo WHERE Artigo.id_Artigo = " + key;
                string s_cmd2 = "DELETE FROM dbo.Quadro WHERE Quadro.id_Artigo = " + key;

                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(s_cmd2, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no remove do ArtigoDAO");
                }
            }
            if (containsKey(key) && containsKeyJoia(key))
            {

                //remove da tabela do artigo
                result = get(key);

                string s_cmd = "DELETE FROM dbo.Artigo WHERE id_Artigo = " + key;
                string s_cmd2 = "DELETE FROM dbo.Joia WHERE id_Artigo = " + key;

                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(s_cmd2, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no remove do ArtigoDAO");
                }
            }
            if (containsKey(key) && containsKeyLivro(key))
            {

                //remove da tabela do artigo
                result = get(key);

                string s_cmd = "DELETE FROM dbo.Artigo WHERE id_Artigo = " + key;
                string s_cmd2 = "DELETE FROM dbo.Livro WHERE id_Artigo = " + key;

                try
                {
                    using (SqlConnection con = new SqlConnection(DAOconfig.GetConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(s_cmd, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(s_cmd2, con))
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception)
                {
                    throw new DAOException("Erro no remove do ArtigoDAO");
                }
            }

            return result;
        }


        //##########################################################################################################################################################################


        public int size()
        {
            int result = 0;
            string s_cmd = "SELECT COUNT(*) FROM dbo.Artigo";
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
                throw new DAOException("Erro no size do ArtigoDAO");
            }
            return result;
        }


        //##########################################################################################################################################################################

        public ICollection<Artigo> values()
        {
            ICollection<Artigo> result = new HashSet<Artigo>();
            string s_cmd = "SELECT * FROM dbo.Artigo";
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
        }

        //##########################################################################################################################################################################

        public bool atualizarDono(int key, string novoDono)
        {
            bool result = false;
            string s_cmd = "UPDATE dbo.Artigo SET fk_email_participante_dono = " + novoDono + " WHERE id_artigo = " + key;

            Console.WriteLine(s_cmd);

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
                throw new DAOException("Erro ao atualizar o dono no ArtigoDAO");
            }
            return result;
        }

    }
}

