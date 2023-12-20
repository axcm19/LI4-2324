namespace LeiloesOnline.Business.Objects

{
    public class Joia : Artigo
    {
        public string material { get; set; }
        public string tipo { get; set; }
        public float pureza_material { get; set; }

        public Joia() : base(0, "", "", "","")
        {
            material = "";
            tipo = "";
            pureza_material = 0;
        }

        public Joia(int id, string nome, string descri, string comp,string email, int idLote, string material, string tipo, float pureza) : base(id, nome, descri, comp,email)
        {
            this.material = material;
            this.tipo = tipo;
            pureza_material = pureza;
        }

        public Joia(Joia q) : base(q.getIdArtigo(), q.getNome(), q.getDescricao(), q.getComprovativo(),q.getEmail())
        {
            material = q.material;
            tipo = q.tipo;
            pureza_material = q.pureza_material;
        }

        public override Joia Clone()
        {
            Joia result = new Joia(this);
            return result;
        }
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