using System;
using tabuleiro;
namespace ConsoleChess
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i<tab.linhas; i++) 
            {
                Console.Write(tab.linhas - i + "  ");
                for (int j=0;j<tab.colunas;j++)
                {
                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("   A B C D E F G H");
        }
        public static void imprimirPeca(Peca peca)
        {
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
        }
    }
}
