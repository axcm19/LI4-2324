using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data.DAOS;

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
            bool result = false;

            if (this.participanteDAO.containsKey(email))
            {
                if (participanteDAO.get(email).user_password == password)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif)
        {
            Console.WriteLine("...");
            return true;
        }

        public Participante getParticipanteWithEmail(string email)
        {
            Console.WriteLine("...");
            return new Participante();
        }

        public Administrador getAdministradorWithEmail(string email)
        {
            Console.WriteLine("...");
            return new Administrador();
        }

        public bool adicionaContaParticipante(Participante participante)
        {
            Console.WriteLine("...");
            return true;
        }

        public bool validarContaNovaParticipante(string email, string username, string morada, float carteira, string pass, int cc, int nif)
        {
            Console.WriteLine("...");
            return true;
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
