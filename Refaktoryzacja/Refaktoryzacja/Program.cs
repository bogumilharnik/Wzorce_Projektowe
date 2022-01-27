using System;

namespace Refaktoryzacja
{
    class Program
    {
        class TikTakToeBoard
        {
            private char[,] box = new char[,] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            public bool Set(int x, int y, char letter)
            {
                if (box[x, y] == ' ')
                {
                    box[x, y] = letter;
                    return true;
                }
                return false;
            }

            public bool CheckWin(char letter)
            {
                return (((box[0, 0] == letter) && (box[0, 1] == letter) && (box[0, 2] == letter)) ||
                        ((box[1, 0] == letter) && (box[1, 1] == letter) && (box[1, 2] == letter)) ||
                        ((box[2, 0] == letter) && (box[2, 1] == letter) && (box[2, 2] == letter)) ||
                        ((box[0, 0] == letter) && (box[1, 0] == letter) && (box[2, 0] == letter)) ||
                        ((box[0, 1] == letter) && (box[1, 1] == letter) && (box[2, 1] == letter)) ||
                        ((box[0, 2] == letter) && (box[1, 2] == letter) && (box[2, 2] == letter)) ||
                        ((box[0, 0] == letter) && (box[1, 1] == letter) && (box[2, 2] == letter)) ||
                        ((box[0, 2] == letter) && (box[1, 1] == letter) && (box[2, 0] == letter)));
            }

            public char Get(int x, int y)
            {
                return box[x, y];
            }
        }

        private static void WriteBoard(TikTakToeBoard board)
        {
            Console.Clear();
            Console.WriteLine(" {0} | {1} | {2} ", board.Get(0, 0), board.Get(0, 1), board.Get(0, 2));
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board.Get(1, 0), board.Get(1, 1), board.Get(1, 2));
            Console.WriteLine(" --------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board.Get(2, 0), board.Get(2, 1), board.Get(2, 2));
            Console.WriteLine();
        }

        public static void NotVacantError()
        {
            Console.WriteLine();
            Console.WriteLine("Error: box not vacant!\nPress any key to try again..");
            Console.ReadKey();
        }

        public static void DisplayLoss()
        {
            Console.WriteLine();
            Console.WriteLine("No one won.");
            Console.ReadKey();
        }

        static void Main()
        {
            Console.WriteLine(" -- Tic Tac Toe -- ");
            TikTakToeBoard board = new TikTakToeBoard();
            for (int moveCount = 0; moveCount < 9; ++moveCount)
            {
                char mark = moveCount % 2 == 0 ? 'X' : 'Y';

                WriteBoard(board);
                Console.WriteLine("What box do you want to place {0} in? (1-9)", mark);
                Console.Write("> ");

                int selTemp = int.Parse(Console.ReadLine());
                if (selTemp >= 1 && selTemp <= 9)
                {
                    if (!board.Set((selTemp - 1) / 3, (selTemp - 1) % 3, mark))
                    {
                        NotVacantError();
                        --moveCount;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong selection entered!\nPress any key to try again..");
                    Console.ReadKey();
                    --moveCount;
                }

                if (board.CheckWin(mark))
                {
                    WriteBoard(board);
                    Console.WriteLine("The winner is {0}!", mark);
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            DisplayLoss();
            Environment.Exit(1);
        }
    }
}
