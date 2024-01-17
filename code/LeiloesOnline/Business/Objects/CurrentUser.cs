using System;

namespace LeiloesOnline.Business.Objects

{
    public class CurrentUser
    {
        /*
         * Esta é uma classe de uma única instância cujo objectivo é armazenar o utilizador com sessão iniciada
         */


        private static Participante? current = null;
        private CurrentUser() { }

        public static void setCurrentUser(Participante user)
        {
            CurrentUser.current = user;
        }

        public static Participante getCurrentUser()
        {
            return CurrentUser.current;
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
                CurrentUser.current.email_participante + "\n" +
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
    }
}