namespace LeiloesOnline.Data

{
    public class Licitacao
    {
        public DateTime data_ocorreu { get; set; }
        public float valor { get; set; } = 0;
        public string email_participante { get; set; } = "";
        public int id_leilao { get; set; } = 0;
    }
}

/*
 CREATE TABLE Licitacao(
	data_ocorreu DATE,
	valor FLOAT,
	fk_email_participante VARCHAR(45) NOT NULL,
	fk_id_leilao INTEGER NOT NULL,
	FOREIGN KEY (fk_email_participante) REFERENCES Participante(email_participante),
	FOREIGN KEY (fk_id_leilao) REFERENCES Leilao(id_leilao),
);
 */