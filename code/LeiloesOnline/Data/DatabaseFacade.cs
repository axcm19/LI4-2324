using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data.DAOS;
using Microsoft.AspNetCore.Components.Forms;

namespace LeiloesOnline.Data
{
    public class DatabaseFacade: IDatabaseFacade
    {
        
        private AdministradorDAO administradorDAO;
        private ParticipanteDAO participanteDAO;
        private ArtigoDAO artigoDAO;
        private LeilaoDAO leilaoDAO;
        private LicitacaoDAO licitacaoDAO;
        private LoteArtigosDAO loteArtigosDAO;

        public DatabaseFacade() 
        { 
            this.administradorDAO = AdministradorDAO.getInstance();
            this.participanteDAO = ParticipanteDAO.getInstance();
            this.artigoDAO = ArtigoDAO.getInstance();
            this.leilaoDAO = LeilaoDAO.getInstance();
            this.licitacaoDAO = LicitacaoDAO.getInstance();
            this.loteArtigosDAO = LoteArtigosDAO.getInstance();
            
        }

        // ---------------------------------------------------- Participantes / Administradores ----------------------------------------------------

        public bool login(string email, string password)
        {
            if (!this.participanteDAO.containsKey(email))
            {
                return false;
            }

            Participante user = this.participanteDAO.get(email);

            string hashedInputPassword = HashPassword(password);

            //comparar hash calculada com a do user 
            return hashedInputPassword == user.user_password;
        }

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif)
        {
            if (!validarContaNovaParticipante(email, username, morada, carteira, pass, cc, nif)) {
                return false;
            }

            string hashedPassword = HashPassword(pass);

            Participante newParticipante = new Participante(email, username, morada, carteira, hashedPassword, cc, nif, null);

            return adicionaContaParticipante(newParticipante);
        }

        public Participante getParticipanteWithEmail(string email)
        {
            Participante result = this.participanteDAO.get(email);
            return result;
        }

        public Administrador getAdministradorWithEmail(string email)
        {
            Console.WriteLine("...");
            return new Administrador();
        }

        public bool adicionaContaParticipante(Participante participante)
        {
            bool result;
            try
            {

                string test_e_mail = "'" + participante.email_participante + "'";
                string test_cc = "'" + participante.cc.ToString() + "'";
                string test_nif = "'" + participante.nif.ToString() + "'";

                if (participanteDAO.containsKey(test_e_mail) || 
                    participanteDAO.existsCC(test_cc) ||
                    participanteDAO.existsNIF(test_nif))
                {
                    result = false;
                }
                else { 
                    participanteDAO.put(participante);
                    result = true;
                }
            
            } catch (Exception) {
                Console.WriteLine("Error in adicionaContaParticipante: ");
                result = false;
            }
            return result;
        }

        public bool validarContaNovaParticipante(string email, string username, string morada, float carteira, string pass, int cc, int nif)
        {
            if(!IsValidEmail(email) && !IsValidCC(cc) && !IsValidNIF(nif)) {
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email) 
        {
            if (string.IsNullOrEmpty(email)) {
                return false;
            }

            int atSignPosition = email.IndexOf('@');
            int dotPosition = email.LastIndexOf('.');

            if (atSignPosition < 1 || dotPosition < atSignPosition + 2 || dotPosition + 2 >= email.Length) {
                return false;
            }

            return true;
        }

        private bool IsValidCC(int cc) 
        {
            return cc.ToString().Length == 8;
        }

        private bool IsValidNIF(int nif) 
        {
            return nif.ToString().Length == 9;
        }

        private string HashPassword(string password) 
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create()) {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public bool criaLivro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag)
        {
            bool result = false;
            int id = Artigo.geraIDArtigoAleatorio();
            Artigo artigo = new Livro(id, nome, descri, comp, CurrentUser.getCurrentUser().email_participante, titulo, nomeautor, ano, editora, numpag);

            if (artigoDAO.containsKey(id) && artigoDAO.containsKeyLivro(id))
            {
                result = false;
            }
            else
            {
                artigoDAO.put(artigo);
                result = true;
            }

            return result;
        }

        public bool criaJoia(string nome, string descri, string comp, string material, string tipo, float pureza)
        {

            bool result = false;
            int id = Artigo.geraIDArtigoAleatorio();
            Artigo artigo = new Joia(id, nome, descri, comp, CurrentUser.getCurrentUser().email_participante, material, tipo, pureza);

            if (artigoDAO.containsKey(id) && artigoDAO.containsKeyJoia(id))
            {
                result = false;
            }
            else
            {
                artigoDAO.put(artigo);
                result = true;
            }

            return result;

        }

        public bool criaQuadro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim)
        {

            bool result = false;
            int id = Artigo.geraIDArtigoAleatorio();
            Artigo artigo = new Quadro(id, nome, descri, comp, CurrentUser.getCurrentUser().email_participante, titulo, nomeautor, ano, dim);

            if (artigoDAO.containsKey(id) && artigoDAO.containsKeyQuadro(id))
            {
                result = false;
            }
            else
            {
                artigoDAO.put(artigo);
                result = true;
            }

            return result;

        }

        public bool transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir)
        {
            return false;    
        }


        /*

        // Bancas
        public bool existsBanca(int idfeira, int idvendedor)
        {
            return bancaDAO.containsKey(new Pair<int, int>(idfeira,idvendedor));
        }
        
        public bool existsBanca(Banca banca)
        {
            return this.existsBanca(banca.getFeiraId(), banca.getVendedorId());
        }

        public Banca getBanca(int idfeira, int idvendedor)
        {
            return this.bancaDAO.get(new Pair<int, int>(idfeira, idvendedor));
        }

        public void addBanca(Banca banca)
        {
            this.bancaDAO.put(new Pair<int, int>(banca.getFeiraId(), banca.getVendedorId()), banca);
        }

        public void removeBanca(int idfeira, int idvendedor)
        {
            this.bancaDAO.remove(new Pair<int, int>(idfeira, idvendedor));
        }

        public ICollection<Banca> getAllBancas()
        {
            return this.bancaDAO.values();
        }

        // Categorias
        public bool existsCategoria(int categoriaid)
        {
            return this.categoriaDAO.containsKey(categoriaid);
        }

        public bool existsCategoria(Categoria categoria)
        {
            return this.categoriaDAO.containsValue(categoria);
        }

        public Categoria getCategoria(int categoriaid)
        {
            return this.categoriaDAO.get(categoriaid);
        }

        public void addCategoria(Categoria categoria)
        {
            this.categoriaDAO.put(categoria.getID(),categoria);
        }

        public void removeCategoria(int categoriaid)
        {
            this.categoriaDAO.remove(categoriaid);
        }

        public ICollection<Categoria> getAllCategorias()
        {
            return this.categoriaDAO.values();
        }

        // Compras

        public bool existsCompra(int compraid)
        {
            return this.compraDAO.containsKey(compraid);
        }

        public bool existsCompra(Compra compra)
        {
            return this.compraDAO.containsValue(compra);
        }

        public Compra getCompra(int compraid)
        {
            return this.compraDAO.get(compraid);
        }

        public void addCompra(Compra compra)
        {
            this.compraDAO.put(compra.getID(), compra);
        }

        public void removeCompra(int compraid)
        {
            this.compraDAO.remove(compraid);
        }

        public ICollection<Compra> getAllCompras()
        {
            return this.compraDAO.values();
        }

        // Feiras
        public bool existsFeira(int feiraid)
        {
            return this.feiraDAO.containsKey(feiraid);
        }

        public bool existsFeira(Feira feira)
        {
            return this.feiraDAO.containsValue(feira);
        }

        public Feira getFeira(int feiraid)
        {
            return this.feiraDAO.get(feiraid);
        }

        public void addFeira(Feira feira)
        {
            this.feiraDAO.put(feira.getId(), feira);
        }

        public void removeFeira(int feiraid)
        {
            this.feiraDAO.remove(feiraid);
        }

        public ICollection<Feira> getAllFeiras()
        {
            return this.feiraDAO.values();
        }

        public ICollection<Feira> getAllFeirasEmCurso()
        {
            return this.feiraDAO.getFeirasEmCurso();
        }

        // Produtos

        public bool existsProduto(int produtoid)
        {
            return this.produtoDAO.containsKey(produtoid);
        }

        public bool existsProduto(Produto produto)
        {
            return this.produtoDAO.containsValue(produto);
        }

        public Produto getProduto(int produtoid)
        {
            return this.produtoDAO.get(produtoid);
        }

        public void addProduto(Produto produto)
        {
            this.produtoDAO.put(produto.getID(), produto);
        }

        public void removeProduto(int produtoid)
        {
            this.produtoDAO.remove(produtoid);
        }

        public ICollection<Produto> getAllProdutos()
        {
            return this.produtoDAO.values();
        }

        public int getQuantidadeDisponivelProduto(int produtoid)
        {
            return this.produtoDAO.getQuantidadeDisponivelProduto(produtoid);
        }
        public int getQuantidadeDisponivelProduto(Produto produto)
        {
            return this.getQuantidadeDisponivelProduto(produto.getID());
        }

        // Subcategorias
        public bool existsSubCategoria(int subcategoriaid)
        {
            return this.subcategoriaDAO.containsKey(subcategoriaid);
        }

        public bool existsSubCategoria(SubCategoria subcategoria)
        {
            return this.subcategoriaDAO.containsValue(subcategoria);
        }

        public SubCategoria getSubCategoria(int subcategoriaid)
        {
            return this.subcategoriaDAO.get(subcategoriaid);
        }

        public void addSubCategoria(SubCategoria subcategoria)
        {
            this.subcategoriaDAO.put(subcategoria.getId(), subcategoria);
        }

        public void removeSubCategoria(int subcategoriaid)
        {
            this.subcategoriaDAO.remove(subcategoriaid);
        }

        public ICollection<SubCategoria> getAllSubCategorias()
        {
            return this.subcategoriaDAO.values();
        }

        

        // relação banca_has_produto

        public void removeProdutoFromBanca(Produto p, Banca b)
        {
            DAOAuxiliar.removeProdutoFromBanca(p,b);
        }

        public void addToBancaHasProduto(Produto p, Banca b)
        {
            DAOAuxiliar.addToBancaHasProduto(p,b);
        }


       */
    }
}
