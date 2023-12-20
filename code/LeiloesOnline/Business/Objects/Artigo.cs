namespace LeiloesOnline.Business.Objects

{
    public abstract class Artigo
    {
        private int id_Artigo;
        private string nome;
        private string descricao;
        private string comprovativo;
        private string fk_email_participante_dono;


        public Artigo()
        {
            id_Artigo = 0;
            nome = "";
            descricao = "";
            comprovativo = "";
            fk_email_participante_dono = "";
        }

        public Artigo(int id, string nome, string descri, string comp,string email)
        {
            id_Artigo = id;
            this.nome = nome;
            descricao = descri;
            comprovativo = comp;
            fk_email_participante_dono = email;
        }

        public Artigo(Artigo art)
        {
            id_Artigo = art.getIdArtigo();
            nome = art.getNome();
            descricao = art.getDescricao();
            comprovativo = art.getComprovativo();
            fk_email_participante_dono = art.getEmail();
        }

        // metodos get e set dão jeito aqui para serem herdados nas subclasses
        public int getIdArtigo()
        { return id_Artigo; }

        public string getNome()
        { return nome; }

        public string getDescricao()
        { return descricao; }

        public string getComprovativo()
        { return comprovativo; }

        public string getEmail()
        { return fk_email_participante_dono; }

        public void setIdArtigo(int newid)
        { id_Artigo = newid; }

        public void setNome(string nome)
        { this.nome = nome; }

        public void setDescricao(string desc)
        { descricao = desc; }

        public void setComprovativo(string comp)
        { comprovativo = comp; }

        public void setEmail(string email)
        { fk_email_participante_dono = email; }

        public abstract Artigo Clone();
    }
}

