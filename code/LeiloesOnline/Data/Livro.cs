namespace LeiloesOnline.Data

{
    public class Livro : Artigo
    {
        public string titulo { get; set; } = "";
        public string nome_autor { get; set; } = "";
        public int ano_edicao { get; set; } = 0;
        public string editora { get; set; } = "";
        public int numero_paginas { get; set; } = 0;
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
