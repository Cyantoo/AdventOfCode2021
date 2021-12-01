using System;
using System.IO;
using Utils;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lines_ints = InputReader.ReadInts("input.txt");
            int result = 0;
            for(int i =3; i<lines_ints.Length; i++)
            {
                if(lines_ints[i-2]+lines_ints[i-1]+lines_ints[i] > lines_ints[i - 3] + lines_ints[i - 2] + lines_ints[i-1])
                {
                    result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
