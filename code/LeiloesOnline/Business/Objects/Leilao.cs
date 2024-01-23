using LeiloesOnline.Business.Objects;
using System.Runtime.CompilerServices;
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

        public string email_quem_propos { get; set; }

        public List<Licitacao> licitacoes;  //  map com as licitaçoes do leilao
        public LoteArtigos lote_artigos;  // lote de artigos do leilão



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
            email_quem_propos = "";
            licitacoes = new List<Licitacao>();
            lote_artigos = new LoteArtigos();
        }

        public Leilao(int id, string categoria, string nome, DateTime di, DateTime df, float preco_base, float min_lic, float lic_atual, bool apro, string email_quem_propos, List<Licitacao> licitacoes, LoteArtigos lote_artigos)
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
            this.email_quem_propos = email_quem_propos;
            this.licitacoes = licitacoes;
            this.lote_artigos = lote_artigos;
            
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
            email_quem_propos = l.email_quem_propos;
            licitacoes = l.licitacoes;
            lote_artigos = l.lote_artigos;
        }

        public Leilao Clone()
        {
            Leilao result = new Leilao(this);
            return result;
        }

        public static int geraIDLeilaoAleatorio()
        {
            Random rnd = new Random();
            int new_id = rnd.Next(10001, 15001); // Gera um número entre 10001 (inclusive) e 15000 (exclusivo)
            return new_id;
        }

        public string printLeilao()
        {
            string res = "";

            res = "--------------------\n" +
                "Leilao: " + id_leilao + "\n" +
                nome + "\n" +
                categoria + "\n" +
                email_quem_propos + "\n" +
                data_inicio + "\n" +
                data_fim + "\n" +
                preco_base + "\n" +
                valor_minimo_licitacao + "\n" +
                "--------------------\n";
            return res;
        }

    }
}
