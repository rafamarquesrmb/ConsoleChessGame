using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace ConsoleChess
{
    class Tela
    {
        
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno.ToString());
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual.ToString());

        }
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas:");
            imprimirConjuntos(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas:");
            imprimirConjuntos(partida.pecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }
        public static void imprimirConjuntos(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i<tab.linhas; i++) 
            {
                Console.Write(tab.linhas - i + "  ");
                for (int j=0;j<tab.colunas;j++)
                {                   
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   A B C D E F G H");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(tab.linhas - i + "  ");
                for (int j = 0; j < tab.colunas; j++)
                {   
                    if(posicoesPossiveis[i,j] == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }
        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else { 
                if(peca.cor == Cor.Branca) {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
