using System.Runtime.InteropServices;

namespace LeiloesOnline.Business.Objects

{
    public class Leilao
    {
        public int id_leilao { get; set; }
        public string categoria { get; set; }
        public string nome { get; set; }
        public DateTime data_inicio { get; set; }
        public DateTime data_fim { get; set; }
        public float preco_base { get; set; }
        public float valor_minimo_licitacao { get; set; }
        public float licitacao_atual { get; set; }
        public bool aprovado { get; set; }

        public Dictionary<string, Licitacao> licitacoes;  //  map com as licitaçoes do leilao
        public LoteArtigos lote_artigos;  // lote de artigos do leilão

        public string email_quem_propos { get; set; }

    public Leilao()
        {
            id_leilao = 0;
            categoria = "";
            nome = "";
            data_inicio = new DateTime();
            data_fim = new DateTime();
            preco_base = 0;
            valor_minimo_licitacao = 0;
            licitacao_atual = 0;
            aprovado = false;
            licitacoes = new Dictionary<string, Licitacao>();
            lote_artigos = new LoteArtigos();
            email_quem_propos = "";
        }

        public Leilao(int id, string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, Dictionary<string, Licitacao> licitacoes, LoteArtigos lote_artigos, string email_quem_propos)
        {
            id_leilao = id;
            this.categoria = categoria;
            this.nome = nome;
            data_inicio = di;
            data_fim = df;
            this.preco_base = preco_base;
            valor_minimo_licitacao = min_lic;
            licitacao_atual = lic_atual;
            aprovado = apro;
            this.licitacoes = licitacoes;
            this.lote_artigos = lote_artigos;
            this.email_quem_propos = email_quem_propos;
        }

        public Leilao(Leilao l)
        {
            id_leilao = l.id_leilao;
            categoria = l.categoria;
            nome = l.nome;
            data_inicio = l.data_inicio;
            data_fim = l.data_fim;
            preco_base = l.preco_base;
            valor_minimo_licitacao = l.valor_minimo_licitacao;
            licitacao_atual = l.licitacao_atual;
            aprovado = l.aprovado;
            licitacoes = l.licitacoes;
            lote_artigos = l.lote_artigos;
            email_quem_propos = l.email_quem_propos;
        }


        public Leilao Clone()
        {
            Leilao result = new Leilao(this);
            return result;
        }

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
