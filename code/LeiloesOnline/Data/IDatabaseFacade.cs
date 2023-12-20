using LeiloesOnline.Business.Objects;

namespace LeiloesOnline.Data
{
    public interface IDatabaseFacade
    {


        public bool login(string email, string password);

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif);

        public Participante getParticipanteWithEmail(string email);

        public Administrador getAdministradorWithEmail(string email);

        public bool adicionaContaParticipante(Participante participante);

        public bool validarContaNovaParticipante(string email, string username, string morada, float carteira, string pass, int cc, int nif);


        /*
        // Bancas
        public bool existsBanca(int idfeira, int idvendedor);

        public bool existsBanca(Banca banca);

        public Banca getBanca(int idfeira, int idvendedor);

        public void addBanca(Banca banca);

        public void removeBanca(int idfeira, int idvendedor);

        public ICollection<Banca> getAllBancas();

        // Categorias
        public bool existsCategoria(int categoriaid);

        public bool existsCategoria(Categoria categoria);

        public Categoria getCategoria(int categoriaid);

        public void addCategoria(Categoria categoria);

        public void removeCategoria(int categoriaid);

        public ICollection<Categoria> getAllCategorias();

        // Compras

        public bool existsCompra(int compraid);

        public bool existsCompra(Compra compra);

        public Compra getCompra(int compraid);

        public void addCompra(Compra compra);

        public void removeCompra(int compraid);

        public ICollection<Compra> getAllCompras();

        // Feiras
        public bool existsFeira(int feiraid);

        public bool existsFeira(Feira feira);

        public Feira getFeira(int feiraid);

        public void addFeira(Feira feira);

        public void removeFeira(int feiraid);

        public ICollection<Feira> getAllFeiras();

        public ICollection<Feira> getAllFeirasEmCurso();

        // Produtos

        public bool existsProduto(int produtoid);

        public bool existsProduto(Produto produto);

        public Produto getProduto(int produtoid);

        public void addProduto(Produto produto);

        public void removeProduto(int produtoid);

        public ICollection<Produto> getAllProdutos();

        public int getQuantidadeDisponivelProduto(int produtoid);

        public int getQuantidadeDisponivelProduto(Produto produto);

        // Subcategorias
        public bool existsSubCategoria(int subcategoriaid);

        public bool existsSubCategoria(SubCategoria subcategoria);

        public SubCategoria getSubCategoria(int subcategoriaid);

        public void addSubCategoria(SubCategoria subcategoria);

        public void removeSubCategoria(int subcategoriaid);

        public ICollection<SubCategoria> getAllSubCategorias();

        // Utilizadores
        public bool existsUtilizador(int utilizadorid);

        public bool existsUtilizador(Utilizador utilizador);

        public Utilizador getUtilizador(int utilizadorid);

        public void addUtilizador(Utilizador utilizador);

        public void removeUtilizador(int utilizadorid);

        public ICollection<Utilizador> getAllUtilizadores();

        public bool existsEmail(string email);
        public bool existsCC(string cc);
        public bool existsNIF(string nif);
        public bool existsUsername(string username);

        public Utilizador getUtilizadorWithEmail(string email);

        // Relação banca_has_produto
        public void removeProdutoFromBanca(Produto p, Banca b);

        public void addToBancaHasProduto(Produto p, Banca b);
        */
    }
}
