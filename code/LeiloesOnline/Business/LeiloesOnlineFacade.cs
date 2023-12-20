using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data;

namespace LeiloesOnline.Business
{
    public class LeiloesOnlineFacade : I_LeiloesOnlineFacade
    {
        private IDatabaseFacade db; // base de dados

        public LeiloesOnlineFacade()
        {
            this.db = new DatabaseFacade(); 
        }

        public bool login(string email, string password)
        {
            return this.db.login(email, password); 
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


        // ---------------------------------------------------- Leiloes ----------------------------------------------------

        public List<Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria)
        {  // criterio e categoria podem ser opcionais
            Console.WriteLine("...");
            return null;
        }

        public Leilao getLeilao(int leilaoID)
        {
            Console.WriteLine("...");
            return new Leilao();
        }

        public bool adicionaNovoLeilao(Leilao newLeilao)
        {
            Console.WriteLine("...");
            return true;
        }

        public Leilao proporLeilao(int id, string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, Dictionary<string, Licitacao> licitacoes, LoteArtigos lote_artigos)
        {
            Console.WriteLine("...");
            return new Leilao();
        }

        public void addLicitacao(int leilaoID, Licitacao newLicitacao)
        { // adiciona uma licitação a uma leilao
            Console.WriteLine("...");
        }

        // ---------------------------------------------------- Artigos ----------------------------------------------------

        public Artigo getArtigo(int artigoID)
        {
            Console.WriteLine("...");
            return new Livro();
        }

        public void criaLivro(int id, string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag)
        {
            Console.WriteLine("...");
        }

        public void criaJoia(int id, string nome, string descri, string comp, string material, string tipo, float pureza)
        {
            Console.WriteLine("...");
        }

        public void criaQuadro(int id, string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim)
        {
            Console.WriteLine("...");
        }

        public void transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir)
        {
            Console.WriteLine("...");
        }
    }
    
}
