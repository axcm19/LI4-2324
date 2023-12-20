namespace LeiloesOnline.Business.Objects

{
    public class LoteArtigos
    {
        public int id_leilao;   // id do leilao a que pertence
        public List<Artigo> artigos;  // lista dos artigos do lote (pode ter um ou mais artigos)

        public LoteArtigos()
        {
            id_leilao = 0;
            artigos = new List<Artigo>();
        }

        public LoteArtigos(int id, List<Artigo> artigos)
        {
            this.id_leilao = id;
            this.artigos = artigos;
        }

        public LoteArtigos(LoteArtigos la)
        {
            id_leilao = la.id_leilao;
            artigos = la.artigos;
        }

        public LoteArtigos Clone()
        {
            LoteArtigos result = new LoteArtigos(this);
            return result;
        }

        public void adicionaArtigoAoLote(Artigo a)
        {
            if(!this.artigos.Contains(a))
            {
                this.artigos.Add(a);        
            }
        }
    }
}

/*
CREATE TABLE Lote_Artigos(
	fk_id_artigo INTEGER,
	fk_id_leilao INTEGER,
	FOREIGN KEY (fk_id_artigo) REFERENCES Artigo(id_artigo),
	FOREIGN KEY (fk_id_leilao) REFERENCES Leilao(id_leilao),
);
 */