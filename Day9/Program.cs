using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sum = 0; 
            List<int> size_basins = new();
            string[] lines = InputReader.ReadLines("input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char height = lines[i][j];
                    bool is_low_point = true;
                    if (i > 0)
                    {
                        if (height >= lines[i - 1][j]) is_low_point = false;
                    }
                    if (j > 0)
                    {
                        if (height >= lines[i][j - 1]) is_low_point = false;
                    }
                    if (i < lines.Length - 1)
                    {
                        if (height >= lines[i + 1][j]) is_low_point = false;
                    }
                    if (j < lines[i].Length - 1)
                    {
                        if (height >= lines[i][j + 1]) is_low_point = false;
                    }
                    if (is_low_point)
                    {
                        // sum += height+1 - '0';
                        int basin_size = FindBasinSize(lines, i, j);
                        size_basins.Add(basin_size);
                        Console.WriteLine(basin_size);

                    }
                }
            }
            size_basins.Sort();
            size_basins.Reverse();
            Console.WriteLine(size_basins[0] * size_basins[1] * size_basins[2]);
        }

        private static int FindBasinSize(string[] lines, int origin_i, int origin_j)
        {
            int size = 0;
            Stack<(int, int)> cellsToTreat = new();
            List<(int, int)> cellsTreated = new();
            cellsToTreat.Push((origin_i, origin_j));
            while (cellsToTreat.Count > 0)
            {
                int i;
                int j;
                (i, j) = cellsToTreat.Pop();
                size++;
                cellsTreated.Add((i, j));
                if (i > 0 && lines[i - 1][j] != '9' && !cellsTreated.Contains((i - 1, j)) &&!cellsToTreat.Contains((i - 1, j))) cellsToTreat.Push((i - 1, j));
                if (j > 0 && lines[i][j - 1] != '9' && !cellsTreated.Contains((i, j - 1)) && !cellsToTreat.Contains((i, j-1))) cellsToTreat.Push((i, j - 1));
                if (i < lines.Length - 1 && lines[i + 1][j] != '9' && !cellsTreated.Contains((i + 1, j)) && !cellsToTreat.Contains((i + 1, j))) cellsToTreat.Push((i + 1, j));
                if (j < lines[origin_i].Length - 1 && lines[i][j + 1] != '9' && !cellsTreated.Contains((i, j + 1)) && !cellsToTreat.Contains((i, j+1))) cellsToTreat.Push((i, j + 1));
            }
            return size;

        }
    }
}
