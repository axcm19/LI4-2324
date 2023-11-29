namespace LeiloesOnline.Business.Objects

{
    public class LoteArtigos
    {
        public int id_lote_artigos { get; set; }
        public List<Artigo> artigos;  // lista dos artigos do lote (pode ter um ou mais artigos)

        public LoteArtigos()
        {
            id_lote_artigos = 0;
            artigos = new List<Artigo>();
        }

        public LoteArtigos(int id, List<Artigo> artigos)
        {
            id_lote_artigos = id;
            this.artigos = artigos;
        }

        public LoteArtigos(LoteArtigos la)
        {
            id_lote_artigos = la.id_lote_artigos;
            artigos = la.artigos;
        }

        public LoteArtigos Clone()
        {
            LoteArtigos result = new LoteArtigos(this);
            return result;
        }
    }
}

/*
 CREATE TABLE Lote_Artigos(
	id_lote_artigos INTEGER NOT NULL,
	fk_id_leilao INTEGER NOT NULL,
	PRIMARY KEY(id_lote_artigos),
	FOREIGN KEY (fk_id_leilao) REFERENCES Leilao(id_leilao),
);
 */