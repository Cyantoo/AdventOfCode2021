using System;
using System.Linq;

namespace Day4
{
    class BingoBoard
    {
        private int[,] board;
        private bool[,] marks;
        public BingoBoard(string[] string_board)
        {
            if (string_board.Length != 5)
            {
                Console.WriteLine("Wrong number of lines when creating BingoBoard");
                return;
            }
            board = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string number = string.Join("", string_board[i].Skip(3 * j).Take(2));
                    board[i, j] = int.Parse(number);
                }

            }
            marks = new bool[5, 5]; // initializes to false


        }

        public bool ProcessNumber(int chosen_number) // returns true if the bingo is now solved
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (board[i, j] == chosen_number)
                    {
                        marks[i, j] = true;
                    }
                }
            }
            return CheckForBingo();
        }

        public int SumRemainingNumbers()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!marks[i, j]) sum += board[i, j];
                }
            }
            return sum;
        }

        public bool CheckForBingo()
        {
            bool result = false;
            // have to check 5 lines, 5 columns
            for (int i = 0; i < 5; i++)
            {
                bool col_all_true = true;
                bool row_all_true = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!marks[i, j]) row_all_true = false;
                    if (!marks[j, i]) col_all_true = false;

                }
                if (col_all_true || row_all_true)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
