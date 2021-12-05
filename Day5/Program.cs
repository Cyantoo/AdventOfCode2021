using System;
using Utils;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = InputReader.ReadLines("input.txt");
            VentDiagram ventDiagram = new();
            foreach(string line in lines)
            {
                ventDiagram.ProcessLine(line);
            }
            ventDiagram.PrintResult();

        }
    }
}
