using Microsoft.VisualBasic;

namespace LeiloesOnline.Data

{
    public class Leilao
    {
        public int id_leilao { get; set; } = 0;
        public string categoria { get; set; } = "";
        public string nome { get; set; } = "";
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public float preco_base { get; set; } = 0;
        public float valor_minimo_liitacao { get; set; } = 0;
        public float licitacao_atual { get; set; } = 0;
        public bool aprovado { get; set; } = false;

        public Dictionary<string, Licitacao> licitacoes = new Dictionary<string, Licitacao>();  //  map com as licitaçoes do leilao
        public LoteArtigos lote_artigos { get; set; } = new LoteArtigos();  // lote de artigos do leilão

    }
}



/*
 CREATE TABLE Leilao(
	id_leilao INTEGER NOT NULL,
	categoria VARCHAR(45),
	nome VARCHAR(45),
	data_inicio DATE,
	data_fim DATE,
	preco_base FLOAT,
	valor_minimo_licitacao FLOAT,
	licitacao_atual FLOAT,
	aprovado BIT,
	fk_email_participante_propos VARCHAR(45) NOT NULL,
	PRIMARY KEY(id_leilao),
	FOREIGN KEY (fk_email_participante_propos) REFERENCES Participante(email_participante),
);
 */
