namespace LeiloesOnline.Data

{
    public class Quadro : Artigo
    {
        public string titulo { get; set; } = "";
        public string nome_autor { get; set; } = "";
        public int ano { get; set; } = 0;
        public string dimensoes { get; set; } = "";
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