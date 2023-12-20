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
    }
}
