using System.Runtime.CompilerServices;
using System.Transactions;

namespace LeiloesOnline.Business.Objects

{
    public class Quadro : Artigo
    {
        public string titulo { get; set; }
        public string nome_autor { get; set; }
        public int ano { get; set; }
        public string dimensoes { get; set; }

        public Quadro() : base(0, "", "", "","")
        {
            titulo = "";
            nome_autor = "";
            ano = 0;
            dimensoes = "";
        }

        public Quadro(int id, string nome, string descri, string comp, string fk_email_participante_dono, string titulo, string nomeautor, int ano, string dim) : base(id, nome, descri, comp, fk_email_participante_dono)
        {

            this.titulo = titulo;
            nome_autor = nomeautor;
            this.ano = ano;
            dimensoes = dim;
        }

        public Quadro(Quadro q) : base(q.getIdArtigo(), q.getNome(), q.getDescricao(), q.getComprovativo(),q.getEmail())
        {
            titulo = q.titulo;
            nome_autor = q.nome_autor;
            ano = q.ano;
            dimensoes = q.dimensoes;
        }

        public override Quadro Clone()
        {
            Quadro result = new Quadro(this);
            return result;
        }
    }
}


/*
 CREATE TABLE Quadro(
	id_artigo INTEGER NOT NULL,
	titulo VARCHAR(45),
	nome_autor VARCHAR(45),
	ano INTEGER,
	dimensoes VARCHAR(45),
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),	
);
 */