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
        
        public bool register(string email, string username, string morada, float carteira, string pass, int cc, int nif) {
            return this.db.register(email, username, morada, carteira, pass, cc, nif);
        }

        public Participante getParticipanteWithEmail(string email)
        {
            return this.db.getParticipanteWithEmail(email);
        }

        public Administrador getAdministradorWithEmail(string email)
        {
            Console.WriteLine("...");
            return new Administrador();
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

        public bool criaLivro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string editora, int numpag)
        {
            return this.db.criaLivro(nome,descri,comp,titulo,nomeautor,ano,editora,numpag);
        }

        public bool criaJoia(string nome, string descri, string comp, string material, string tipo, float pureza)
        {
            return this.db.criaJoia(nome, descri, comp,material,tipo,pureza);
        }

        public bool criaQuadro(string nome, string descri, string comp, string titulo, string nomeautor, int ano, string dim)
        {
            return this.db.criaQuadro(nome, descri, comp, titulo, nomeautor, ano, dim);
        }

        public bool transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir)
        {
            Console.WriteLine("...");
            return false;
        }
    }
    
}
