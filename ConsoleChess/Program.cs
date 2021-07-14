using System;
using tabuleiro;
using xadrez;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try { 
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno.ToString());
                    Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual.ToString());


                    Console.WriteLine();
                    Console.Write("Digite a Posição de Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab,posicoesPossiveis);

                    Console.Write("Digite a Posição de Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);
                    partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }                               
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
