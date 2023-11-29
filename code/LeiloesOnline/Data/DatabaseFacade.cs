using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data.DAOS;

namespace LeiloesOnline.Data
{
    public class DatabaseFacade: IDatabaseFacade
    {
        /*
        private BancaDAO bancaDAO;
        private CategoriaDAO categoriaDAO;
        private CompraDAO compraDAO;
        private FeiraDAO feiraDAO;
        private ProdutoDAO produtoDAO;
        private SubCategoriaDAO subcategoriaDAO;
        private UtilizadorDAO utilizadorDAO;

        public DatabaseFacade() 
        { 
            this.bancaDAO = BancaDAO.getInstance();
            this.categoriaDAO = CategoriaDAO.getInstance();
            this.compraDAO = CompraDAO.getInstance();
            this.feiraDAO = FeiraDAO.getInstance();
            this.produtoDAO = ProdutoDAO.getInstance();
            this.subcategoriaDAO = SubCategoriaDAO.getInstance();
            this.utilizadorDAO = UtilizadorDAO.getInstance();
            
        }

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

        // Utilizadores
        public bool existsUtilizador(int utilizadorid)
        {
            return this.utilizadorDAO.containsKey(utilizadorid);
        }

        public bool existsUtilizador(Utilizador utilizador)
        {
            return this.utilizadorDAO.containsValue(utilizador);
        }

        public Utilizador getUtilizador(int utilizadorid)
        {
            return this.utilizadorDAO.get(utilizadorid);
        }

        public void addUtilizador(Utilizador utilizador)
        {
            this.utilizadorDAO.put(utilizador.getID(), utilizador);
        }

        public void removeUtilizador(int utilizadorid)
        {
            this.utilizadorDAO.remove(utilizadorid);
        }

        public ICollection<Utilizador> getAllUtilizadores()
        {
            return this.utilizadorDAO.values();
        }

        public bool existsEmail(string email)
        {
            return this.utilizadorDAO.existsEmail(email);
        }

        public bool existsCC(string cc)
        {
            return this.utilizadorDAO.existsCC(cc);
        }
        public bool existsNIF(string nif)
        {
            return this.utilizadorDAO.existsNIF(nif);
        }
        public bool existsUsername(string username)
        {
            return this.utilizadorDAO.existsUsername(username);
        }

        public Utilizador getUtilizadorWithEmail(string email)
        {
            return this.utilizadorDAO.getUtilizadorByEmail(email);
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
