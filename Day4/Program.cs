using System;
using Utils;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parse Input
            string[] lines = InputReader.ReadLines("input.txt");
            int[] chosen_numbers = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));
            // Parse bingo boards
            List<BingoBoard> bingoBoards = new();
            for(int i = 2; i<lines.Length;  i+=6 )
            {
                bingoBoards.Add(new BingoBoard(lines.Skip(i).Take(5).ToArray()));
            }
            foreach (int chosen_number in chosen_numbers)
            {
                foreach(BingoBoard bingoBoard in new List<BingoBoard>(bingoBoards))
                {
                    if(bingoBoard.ProcessNumber(chosen_number))
                    {
                        bingoBoards.Remove(bingoBoard);
                    }
                    if(bingoBoards.Count == 0)
                    {
                        Console.WriteLine(bingoBoard.SumRemainingNumbers() * chosen_number);
                        return;
                    }
                }
            }
        }

    }
}


/* Part 1
 *        static void Main(string[] args)
        {
            // Parse Input
            string[] lines = InputReader.ReadLines("input.txt");
            int[] chosen_numbers = Array.ConvertAll(lines[0].Split(','), s => int.Parse(s));
            // Parse bingo boards
            List<BingoBoard> bingoBoards = new();
            for(int i = 2; i<lines.Length;  i+=6 )
            {
                bingoBoards.Add(new BingoBoard(lines.Skip(i).Take(5).ToArray()));
            }
            foreach (int chosen_number in chosen_numbers)
            {
                foreach(BingoBoard bingoBoard in bingoBoards)
                {
                    if(bingoBoard.ProcessNumber(chosen_number))
                    {
                        Console.WriteLine(bingoBoard.SumRemainingNumbers() * chosen_number);
                        return;
                    }
                }
            }
        }
*/
