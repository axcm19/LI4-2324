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

        public bool loginAdmi(string email, string password)
        {
            if (!this.administradorDAO.containsKey(email))
            {
                return false;
            }

            Administrador admi = this.administradorDAO.get(email);

            string hashedInputPassword = HashPassword(password);

            //comparar hash calculada com a do admi 
            return hashedInputPassword == admi.admi_password;
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
            result.meusArtigos = this.participanteDAO.getArtigos(email);
            return result;
        }

        public Dictionary<int, Licitacao> getLicitacoes(int id_leilao, string email)
        {
            return this.licitacaoDAO.getAllLicitacoes(id_leilao, email);
        }

        public Dictionary<int, Leilao> getParticipanteLeiloes(string email)
        {
            return this.leilaoDAO.getAllLeiloesParticipante(email);
        }

        public Administrador getAdministradorWithEmail(string email)
        {
            Administrador result = this.administradorDAO.get(email);
            return result;
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
                CurrentUser.getCurrentUser().meusArtigos.Add(artigo.getIdArtigo(),artigo);
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
                CurrentUser.getCurrentUser().meusArtigos.Add(artigo.getIdArtigo(), artigo);
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
                CurrentUser.getCurrentUser().meusArtigos.Add(artigo.getIdArtigo(), artigo);
                result = true;
            }

            return result;

        }

        public bool transfereArtigo(string email_vendedor, string email_comprador, Artigo artigoParaTransferir)
        {
            return false;    
        }


        public bool proporLeilao(string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, string email_quem_propos_, Dictionary<int, Licitacao> licitacoes, LoteArtigos lote_artigos)
        {

            bool result = false;
            int id = Leilao.geraIDLeilaoAleatorio();
            Leilao leilao = new Leilao(id, categoria, nome, di, df, preco_base, min_lic, lic_atual, apro, email_quem_propos_,licitacoes, lote_artigos);

            if (leilaoDAO.containsKey(id))
            {
                result = false;
            }
            else
            {
                leilaoDAO.put(leilao);
                result = true;
            }

            return result;

        }

        public bool eliminarLeilao(int id_leilao)
        {

            bool result = false;

            if (leilaoDAO.containsKey(id_leilao))
            {
                leilaoDAO.remove(id_leilao);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool eliminarParticipante(string email)
        {

            bool result = false;

            if (participanteDAO.containsKey(email))
            {
                participanteDAO.remove(email);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public Dictionary<int, Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria, int quais)
        {
            // quais = 1 --> vai buscar só os que estão aprovados
            // quais = 2 --> vai buscar todos os leiloes à BD
            if(quais == 1)
            {
                return leilaoDAO.getAllLeiloesAprovados(criterioDeOrdenacao, categoria);
            }
            if(quais == 2)
            {
                return leilaoDAO.getAllLeiloes();
            }
            else
            {
                return new Dictionary<int, Leilao>();
            }
        }

        public bool aprovarLeilao(int leilaoID, int valor)
        {
            bool result = false;

            if (leilaoDAO.containsKey(leilaoID))
            {
                leilaoDAO.aprovar(leilaoID, valor);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public Artigo getArtigo(int artigoID)
        {
            Artigo result = this.artigoDAO.get(artigoID);
            return result;
        }

        public bool carregaSaldo(string e_mail, float valor)
        {
            bool result = false;

            if (participanteDAO.containsKey(e_mail))
            {
                participanteDAO.carregaSaldo(e_mail, valor);
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool addLicitacao(Licitacao newLicitacao)
        {
            bool result = false;
            Licitacao copy_l = newLicitacao.Clone();

            string test_e_mail = "'" + copy_l.email_participante + "'";

            if (licitacaoDAO.containsKeys(test_e_mail, copy_l.id_leilao))
            {
                result = false;
            }
            else
            {
                licitacaoDAO.put(copy_l);
                result = true;
            }

            return result;
        }

        public Leilao getLeilao(int leilaoID)
        {
            Leilao result = this.leilaoDAO.get(leilaoID);
            result.lote_artigos.artigos = this.leilaoDAO.getArtigos(leilaoID);
            return result;
        }

    }
}
