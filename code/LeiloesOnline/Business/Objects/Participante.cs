using System;

namespace LeiloesOnline.Business.Objects

{
    public class Participante
    {
        public string email_participante { get; set; }
        public string username { get; set; }
        public string morada { get; set; }
        public float carteira { get; set; }
        public string user_password { get; set; }
        public int cc { get; set; }
        public int nif { get; set; }
        public Dictionary<int, Artigo> meusArtigos;

        public Participante()
        {
            email_participante = "";
            username = "";
            morada = "";
            carteira = 0;
            user_password = "";
            cc = 0;
            nif = 0;
            meusArtigos = new Dictionary<int, Artigo>();
        }

        public Participante(string email, string username, string morada, float carteira, string pass, int cc, int nif, Dictionary<int, Artigo> meusArtigos)
        {
            email_participante = email;
            this.username = username;
            this.morada = morada;
            this.carteira = carteira;
            user_password = pass;
            this.cc = cc;
            this.nif = nif;
            this.meusArtigos = meusArtigos;
        }

        public Participante(Participante p)
        {
            email_participante = p.email_participante;
            username = p.username;
            morada = p.morada;
            carteira = p.carteira;
            user_password = p.user_password;
            cc = p.cc;
            nif = p.nif;
            meusArtigos = p.meusArtigos;
        }

        public Participante Clone()
        {
            Participante result = new Participante(this);
            return result;
        }

        public string printUserInfo()
        {
            string res = "";
            res = "--------------------\n" +
                this.email_participante + "\n" +
                this.username + "\n" +
                this.morada + "\n" +
                this.carteira + "\n" +
                this.user_password + "\n" +
                this.cc + "\n" +
                this.nif + "\n" +
                "--------------------\n";
            return res;
        }

    }
}