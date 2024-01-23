using System;
using System.Reflection.Metadata.Ecma335;

namespace LeiloesOnline.Business.Objects

{
    public class CurrentUser
    {
        /*
         * Esta é uma classe de uma única instância cujo objectivo é armazenar o utilizador com sessão iniciada
         */


        private static Participante? current = null;
        private static float dividaAcumulada = 0;
        private CurrentUser() { }

        public static float calculaDivida()
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            float res = 0;

            string test_e_mail = "'" + current.email_participante + "'";
            List<Licitacao> licitacoes = if_leiloes.getLicitacoes(0, test_e_mail);

            if (licitacoes.Count != 0)
            {
                foreach (var item in licitacoes)
                {
                    // só contam as licitaçoes para leiloes que estejam ativos
                    if (if_leiloes.getLeilao(item.id_leilao).aprovado == true)
                    {
                        res += item.valor;
                    }
                }
            }
            return res;
        }


        public static void setCurrentUser(Participante user)
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            CurrentUser.current = user;
            CurrentUser.dividaAcumulada = calculaDivida();
        }

        public static void setDivida(float valor)
        {
            CurrentUser.dividaAcumulada = valor;
        }

        public static Participante getCurrentUser()
        {
            return CurrentUser.current;
        }

        public static float getDivida()
        {
            return CurrentUser.dividaAcumulada;
        }

        public static string printArtigos()
        {
            string result = "";

            foreach (var parChaveValor in CurrentUser.current.meusArtigos)
            {
                int chave = parChaveValor.Key;
                Artigo valor = parChaveValor.Value;

                result += chave + " -> " + valor.GetType().Name + ", " + valor.getNome() + " \n ";
            }

            return result;
        }

        public static string printCurrentUserInfo()
        {
            string res = "";
            string ar = printArtigos();

            res = "--------------------\n" +
                "Participante Atual: " + CurrentUser.current.email_participante + "\n" +
                CurrentUser.current.username + "\n" +
                CurrentUser.current.morada + "\n" +
                CurrentUser.current.carteira + "\n" +
                CurrentUser.current.user_password + "\n" +
                CurrentUser.current.cc + "\n" +
                CurrentUser.current.nif + "\n" +
                "Artigos:" + "\n" +
                ar + "\n" +
                "--------------------\n"; 
            return res;
        }

        public static Dictionary<int, Leilao> getMyLeiloes()
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            string test_e_mail = "'" + current.email_participante + "'";
            return if_leiloes.getParticipanteLeiloes(test_e_mail);
        }

        public static List<Licitacao> getMyLicitacoes()
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            string test_e_mail = "'" + current.email_participante + "'";
            return if_leiloes.getLicitacoes(0, test_e_mail);
        }

        public static bool carregaSaldo(float valor)
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            string test_e_mail = "'" + current.email_participante + "'";
            current.carteira = valor;
            return if_leiloes.carregaSaldo(test_e_mail, valor);
        }
    }
}