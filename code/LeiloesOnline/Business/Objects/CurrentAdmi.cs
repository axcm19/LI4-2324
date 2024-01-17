using System;

namespace LeiloesOnline.Business.Objects

{
    public class CurrentAdmi
    {
        /*
         * Esta é uma classe de uma única instância cujo objectivo é armazenar o administrador com sessão iniciada
         */


        private static Administrador? current = null;
        private CurrentAdmi() { }

        public static void setCurrentAdmi(Administrador ad)
        {
            CurrentAdmi.current = ad;
        }

        public static Administrador getCurrentAdmi()
        {
            return CurrentAdmi.current;
        }

        public static string printCurrentAdmiInfo()
        {
            string res = "";

            res = "--------------------\n" +
                CurrentAdmi.current.email_administrador + "\n" +
                CurrentAdmi.current.username + "\n" +
                CurrentAdmi.current.admi_password + "\n" +
                "--------------------\n"; 
            return res;
        }

    }
}