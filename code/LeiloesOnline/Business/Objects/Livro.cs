namespace LeiloesOnline.Business.Objects

{
    public class Livro : Artigo
    {
        public string titulo { get; set; }
        public string nome_autor { get; set; }
        public int ano_edicao { get; set; }
        public string editora { get; set; }
        public int numero_paginas { get; set; }

        public Livro() : base(0, "", "", "","")
        {
            titulo = "";
            nome_autor = "";
            ano_edicao = 0;
            editora = "";
            numero_paginas = 0;
        }

        public Livro(int id, string nome, string descri, string comp,string email, string titulo, string nomeautor, int ano, string editora, int numpag) : base(id, nome, descri, comp,email)
        {
            this.titulo = titulo;
            nome_autor = nomeautor;
            ano_edicao = ano;
            this.editora = editora;
            numero_paginas = numpag;
        }

        public Livro(Livro q) : base(q.getIdArtigo(), q.getNome(), q.getDescricao(), q.getComprovativo(),q.getEmail())
        {
            titulo = q.titulo;
            nome_autor = q.nome_autor;
            ano_edicao = q.ano_edicao;
            editora = q.editora;
            numero_paginas = q.numero_paginas;
        }

        public override Livro Clone()
        {
            Livro result = new Livro(this);
            return result;
        }
    }
}

/*
 CREATE TABLE Livro(
	id_artigo INTEGER NOT NULL,
	titulo VARCHAR(45),
	nome_autor VARCHAR(45),
	ano_edicao INTEGER,
	editora VARCHAR(45),
	numero_paginas INTEGER,
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),
);
 */
