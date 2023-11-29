using System.Runtime.InteropServices;

namespace LeiloesOnline.Business.Objects

{
    public class Licitacao
    {
        public DateTime data_ocorreu { get; set; }
        public float valor { get; set; }
        public string email_participante { get; set; }
        public int id_leilao { get; set; }

        public Licitacao()
        {
            data_ocorreu = new DateTime();
            valor = 0;
            email_participante = "";
            id_leilao = 0;
        }

        public Licitacao(DateTime d, float v, string email, int idleilao)
        {
            data_ocorreu = d;
            valor = v;
            email_participante = email;
            id_leilao = idleilao;
        }

        public Licitacao(Licitacao lic)
        {
            data_ocorreu = lic.data_ocorreu;
            valor = lic.valor;
            email_participante = lic.email_participante;
            id_leilao = lic.id_leilao;
        }

        public Licitacao Clone()
        {
            Licitacao result = new Licitacao(this);
            return result;
        }
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