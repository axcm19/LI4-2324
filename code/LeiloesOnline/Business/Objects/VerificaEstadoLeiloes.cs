using LeiloesOnline.Data;
using LeiloesOnline.Data.DAOS;
using LeiloesOnline.Pages;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace LeiloesOnline.Business.Objects
{
    public class VerificaEstadoLeiloes
    {
        public string verifica()
        {
            I_LeiloesOnlineFacade if_leiloes = new LeiloesOnlineFacade();
            Dictionary<int, Leilao> todosLeiloes = if_leiloes.getTodosLeiloes("", "", 1);

            string aviso = "";

            foreach (Leilao leilao in todosLeiloes.Values)
            {

                DateTime dataAtual = DateTime.Now;
                DateTime dataTérmino = leilao.data_fim;

                if (dataAtual > dataTérmino)
                {
                    // ir buscar a ultima licitação feita
                    float valorVencedor = leilao.licitacao_atual;
                    string vencedor = "";

                    // ir buscar o email do vencedor
                    foreach (Licitacao l in if_leiloes.getLicitacoes(leilao.id_leilao, ""))
                    {
                        if (l.valor == valorVencedor)
                        {
                            vencedor = l.email_participante;
                            if_leiloes.aprovarLeilao(l.id_leilao, 0); // leilao deixa de estar aprovado

                            string test_e_mail_vencedor = "'" + vencedor + "'";
                            string test_e_mail_proponente = "'" + if_leiloes.getLeilao(leilao.id_leilao).email_quem_propos + "'";

                            float valor_a_descontar = if_leiloes.getParticipanteWithEmail(test_e_mail_vencedor).carteira - valorVencedor;
                            float valor_a_acrescentar = if_leiloes.getParticipanteWithEmail(test_e_mail_proponente).carteira + valorVencedor;

                            // transação de dinheiro entre vencedor e proponente
                            if_leiloes.carregaSaldo(test_e_mail_vencedor, valor_a_descontar);   
                            if_leiloes.carregaSaldo(test_e_mail_proponente, valor_a_acrescentar);

                            // se o current user for o vencedor
                            if (CurrentUser.getCurrentUser().email_participante.Equals(vencedor))
                            {
                                CurrentUser.carregaSaldo(valor_a_descontar);
                                CurrentUser.setDivida(CurrentUser.calculaDivida());
                            }

                            // se o current user for o proponente
                            if (CurrentUser.getCurrentUser().email_participante.Equals(if_leiloes.getLeilao(leilao.id_leilao).email_quem_propos))
                            {
                                CurrentUser.carregaSaldo(CurrentUser.getCurrentUser().carteira + valorVencedor);
                            }


                            // transferir os artigos do inventário do proponente para o inventário do vencedor
                            Leilao copia = if_leiloes.getLeilao(leilao.id_leilao);  // tive de ir mesmo buscar à BD senão ele não sabia quais eram os artigos
                            foreach (Artigo a in copia.lote_artigos.artigos)
                            {
                                Console.WriteLine(a.getIdArtigo());

                                if (if_leiloes.transfereArtigo(if_leiloes.getLeilao(leilao.id_leilao).email_quem_propos, vencedor, a) == true)
                                {
                                    Console.WriteLine("Artigo transferido com sucesso");
                                }
                                else
                                {
                                    Console.WriteLine("Erro a transferir artigo");
                                }
                            }

                            // caso o currentUser seja o proponente ou vencedor do leilão, deve atualizar o seu inventário
                            if (CurrentUser.getCurrentUser().email_participante.Equals(vencedor))
                            {
                                CurrentUser.getCurrentUser().meusArtigos = CurrentUser.getArtigos();
                            }


                            return "O leilão " + leilao.id_leilao + " terminou com o vencedor " + vencedor + " -> Licitação vencedora = " + valorVencedor;
                        }

                    }
                }
            }
            return aviso;
        }

    }
}