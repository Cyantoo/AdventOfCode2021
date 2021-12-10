using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = InputReader.ReadLines("input.txt")[0];
            List<int> initial_school = new(Array.ConvertAll(line.Split(','), s => int.Parse(s)));
            // Transform into an array of size 8
            long[] current_school = new long[9];
            foreach (int days in initial_school)
            {
                current_school[days]++;
            }
            for (int generation = 0; generation < 256; generation++)
            {
                long[] new_school = new long[9];
                // case 0
                new_school[8] += current_school[0];
                new_school[6] += current_school[0];
                for (int i = 0; i < 8; i++)
                {
                    new_school[i] += current_school[i + 1];
                }
                current_school = new_school;
            }
            Console.WriteLine(current_school.Sum());
        }
    }
}

/* Part 1 (naive):
 * string line = InputReader.ReadLines("input.txt")[0];
            List<int> current_school = new(Array.ConvertAll(line.Split(','), s => int.Parse(s)));
            for(int generation =0; generation < 256; generation++)
            {
                Console.WriteLine(generation);
                List<int> new_school = new();
                foreach(int lanternfish in current_school)
                {
                    if (lanternfish ==0)
                    {
                        new_school.Add(6);
                        new_school.Add(8);
                    }
                    else
                    {
                        new_school.Add(lanternfish - 1);
                    }
                }
                current_school = new_school;
            }
            Console.WriteLine(current_school.Count);
*/
