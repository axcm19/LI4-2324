using System;
namespace LeiloesOnline.Data

{ 
    public class Participante
    {
        public string email_participante { get; set; } = "";
        public string username { get; set; } = "";
        public string morada { get; set; } = "";
        public float carteira { get; set; } = 0;
        public string user_password { get; set; } = "";
        public int cc { get; set; } = 0;
        public int nif { get; set; } = 0;
        public Dictionary<int, Artigo> meusArtigos = new Dictionary<int, Artigo>();

    }
}