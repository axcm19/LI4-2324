using System;

namespace LeiloesOnline.Business.Objects

{
    public class CurrentLeilao
    {
        /*
         * Esta é uma classe de uma única instância cujo objectivo é armazenar o leilão que o utilizador atual está a visualizar
         * Deve ser "limpo" quando o utilizador sai da pagina do leilão.
         */


        private static Leilao? current = null;
        private CurrentLeilao() { }

        public static void setCurrentLeilao(Leilao l)
        {
            CurrentLeilao.current = l;
        }

        public static Leilao getCurrentLeilao()
        {
            return CurrentLeilao.current;
        }

        public static string printArtigos()
        {
            string result = "";

            foreach (var artigo in CurrentLeilao.current.lote_artigos.artigos)
            {
                result += artigo.getIdArtigo() + " -> " + artigo.GetType().Name + ", " + artigo.getNome() + " \n ";
            }

            return result;
        }

        public static string printCurrentLeilaoInfo()
        {
            string res = "";
            string ar = printArtigos();

            res = "--------------------\n" +
                CurrentLeilao.current.id_leilao + "\n" +
                CurrentLeilao.current.nome+ "\n" +
                CurrentLeilao.current.categoria+ "\n" +
                CurrentLeilao.current.email_quem_propos + "\n" +
                CurrentLeilao.current.data_inicio + "\n" +
                CurrentLeilao.current.data_fim + "\n" +
                CurrentLeilao.current.preco_base+ "\n" +
                CurrentLeilao.current.valor_minimo_licitacao + "\n" +
                "Artigos:" + "\n" +
                ar + "\n" +
                "--------------------\n"; 
            return res;
        }

        public static Dictionary<int, Licitacao> getMyLicitacoes()
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            return if_leiloes.getLicitacoes(CurrentLeilao.getCurrentLeilao().id_leilao, "");
        }
    }
}