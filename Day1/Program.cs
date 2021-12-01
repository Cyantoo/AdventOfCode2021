using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(projectDirectory);
            string[] lines = File.ReadAllLines(projectDirectory+@"\input.txt");
            int[] lines_ints = Array.ConvertAll(lines, s => int.Parse(s));
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
