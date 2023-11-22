namespace LeiloesOnline.Data

{
    public class LoteArtigos
    {
        public int id_lote_artigos { get; set; } = 0;
        public List<Artigo> artigos = new List<Artigo>();   // lista dos artigos do lote (pode ter um ou mais artigos)
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