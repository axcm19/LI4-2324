namespace LeiloesOnline.Business.Objects

{
    public abstract class Artigo
    {
        private int id_Artigo;
        private string nome;
        private string descricao;
        private string comprovativo;


        public Artigo()
        {
            id_Artigo = 0;
            nome = "";
            descricao = "";
            comprovativo = "";
        }

        public Artigo(int id, string nome, string descri, string comp)
        {
            id_Artigo = id;
            this.nome = nome;
            descricao = descri;
            comprovativo = comp;
        }

        public Artigo(Artigo art)
        {
            id_Artigo = art.getIdArtigo();
            nome = art.getNome();
            descricao = art.getDescricao();
            comprovativo = art.getComprovativo();
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

        public void setIdArtigo(int newid)
        { id_Artigo = newid; }

        public void setNome(string nome)
        { this.nome = nome; }

        public void setDescricao(string desc)
        { descricao = desc; }

        public void setComprovativo(string comp)
        { comprovativo = comp; }

        public abstract Artigo Clone();
    }
}

