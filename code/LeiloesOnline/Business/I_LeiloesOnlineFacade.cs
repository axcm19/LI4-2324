using LeiloesOnline.Business.Objects;

namespace LeiloesOnline.Business
{
    public interface I_LeiloesOnlineFacade
    {
        /*
         * metodos a implementar
        */

        // ---------------------------------------------------- Participantes / Administradores ----------------------------------------------------

        /*
        * Não se cria ou valida contas de administradores. Isso deve ser feito diretamente na BD. 
        * Já existe um administrador na BD.
        */

        public bool login(string email, string password);

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif);

        public Participante getParticipanteWithEmail(string email);

        public Administrador getAdministradorWithEmail(string email);


        // ---------------------------------------------------- Leiloes ----------------------------------------------------

        public List<Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria); // criterio e categoria podem ser opcionais

        public Leilao getLeilao(int leilaoID);

        public bool adicionaNovoLeilao(Leilao newLeilao);

        public Leilao proporLeilao(int id, string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, Dictionary<string, Licitacao> licitacoes, LoteArtigos lote_artigos);

        public void addLicitacao(int leilaoID, Licitacao newLicitacao); // adiciona uma licitação a uma leilao

        // ---------------------------------------------------- Artigos ----------------------------------------------------

        public Artigo getArtigo(int artigoID);

        public void criaLivro(int id, string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag);

        public void criaJoia(int id, string nome, string descri, string comp, string material, string tipo, float pureza);

        public void criaQuadro(int id, string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim);

        public void transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir);
       
    }
}
