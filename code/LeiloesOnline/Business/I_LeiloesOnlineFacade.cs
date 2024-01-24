using LeiloesOnline.Business.Objects;
using System.Drawing;

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

        public bool loginAdmi(string email, string password);

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif);

        public Participante getParticipanteWithEmail(string email);

        public Dictionary<int, Artigo> getParticipanteArtigos(string email);

        public Administrador getAdministradorWithEmail(string email);

        public bool carregaSaldo(string e_mail, float valor);


        // ---------------------------------------------------- Leiloes ----------------------------------------------------


        public Dictionary<int, Leilao> getParticipanteLeiloes(string email);

        public Dictionary<int, Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria, int quais); // criterio e categoria podem ser opcionais

        public List<Licitacao> getLicitacoes(int id_leilao, string email);


        public Leilao getLeilao(int leilaoID);

        public bool proporLeilao(string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, string email_quem_propos_, List<Licitacao> licitacoes, LoteArtigos lote_artigos);

        public bool aprovarLeilao(int leilaoID, int valor);

        public bool addLicitacao(Licitacao newLicitacao); // adiciona uma licitação a uma leilao 

        // ---------------------------------------------------- Artigos ----------------------------------------------------

        public Artigo getArtigo(int artigoID);

        public bool criaLivro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag);

        public bool criaJoia(string nome, string descri, string comp, string material, string tipo, float pureza);

        public bool criaQuadro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim);

        public bool transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir);

        public bool eliminarLeilao(int id_leilao);

        public bool eliminarParticipante(string email);

    }
}
