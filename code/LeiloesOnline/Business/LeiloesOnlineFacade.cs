using LeiloesOnline.Business.Objects;
using LeiloesOnline.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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

        public bool loginAdmi(string email, string password)
        {
            return this.db.loginAdmi(email, password);
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
            return this.db.getAdministradorWithEmail(email);
        }

        public bool carregaSaldo(string e_mail, float valor)
        {
            return this.db.carregaSaldo(e_mail, valor);
        }


        // ---------------------------------------------------- Leiloes ----------------------------------------------------


        public Dictionary<int, Licitacao> getLicitacoes(int id_leilao, string email)
        {
            return this.db.getLicitacoes(id_leilao, email);
        }

        public Dictionary<int, Leilao> getParticipanteLeiloes(string email)
        {
            return this.db.getParticipanteLeiloes(email);
        }

        public Dictionary<int, Leilao> getTodosLeiloes(string criterioDeOrdenacao, string categoria, int quais)
        {
            return this.db.getTodosLeiloes(criterioDeOrdenacao, categoria, quais);
        }

        public Leilao getLeilao(int leilaoID)
        {
            return this.db.getLeilao(leilaoID);
        }


        public bool proporLeilao(string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, string email_quem_propos_, Dictionary<int, Licitacao> licitacoes, LoteArtigos lote_artigos)
        {
            return this.db.proporLeilao(categoria, nome, di, df, preco_base, min_lic, lic_atual, apro, email_quem_propos_,licitacoes, lote_artigos);
        }

        public bool addLicitacao(Licitacao newLicitacao)
        { // adiciona uma licitação a uma leilao
            return this.db.addLicitacao(newLicitacao);
        }

        public bool eliminarLeilao(int id_leilao)
        {
            return this.db.eliminarLeilao(id_leilao);
        }

        public bool eliminarParticipante(string email)
        {
            return this.db.eliminarParticipante(email);
        }

        public bool aprovarLeilao(int leilaoID, int valor)
        {
            return this.db.aprovarLeilao(leilaoID, valor);
        }

        // ---------------------------------------------------- Artigos ----------------------------------------------------

        public Artigo getArtigo(int artigoID)
        {
            return this.db.getArtigo(artigoID);
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
