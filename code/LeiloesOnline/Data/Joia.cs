namespace LeiloesOnline.Data

{
    public class Joia : Artigo
    {
        public string material { get; set; } = "";
        public string tipo { get; set; } = "";
        public float pureza_material { get; set; } = 0;
    }
}


/*
 CREATE TABLE Joia(
	id_artigo INTEGER NOT NULL,
	material VARCHAR(45),
	tipo VARCHAR(45),
	pureza_material FLOAT,
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),	
);
 */