using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data.DAOS;

namespace LeiloesOnline.Data
{
    public interface IDatabaseFacade
    {


        public bool login(string email, string password);

        public bool loginAdmi(string email, string password);

        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif);

        public Participante getParticipanteWithEmail(string email);

        public Administrador getAdministradorWithEmail(string email);

        public bool adicionaContaParticipante(Participante participante);

        public bool validarContaNovaParticipante(string email, string username, string morada, float carteira, string pass, int cc, int nif);

        public bool criaLivro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag);

        public bool criaJoia(string nome, string descri, string comp, string material, string tipo, float pureza);

        public bool criaQuadro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim);

        public bool transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir);

        public bool carregaSaldo(string e_mail, float valor);

        public Dictionary<int, Leilao> getParticipanteLeiloes(string email);

        public bool proporLeilao(string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, string email_quem_propos_, Dictionary<string, Licitacao> licitacoes, LoteArtigos lote_artigos);

        public Dictionary<int, Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria);

        public bool eliminarLeilao(int id_leilao);

        public bool eliminarParticipante(string email);

        public bool aprovarLeilao(int leilaoID);

        public Artigo getArtigo(int artigoID);

        public Dictionary<int, Licitacao> getLicitacoes(int leilaoID, string email);

        public bool addLicitacao(Licitacao newLicitacao);

    }
}
