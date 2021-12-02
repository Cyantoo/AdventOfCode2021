using System;
using Utils;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = InputReader.ReadLines("input.txt");
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach(string line in lines)
            {
                string[] splits = line.Split(' ');
                int magnitude = int.Parse(splits[1]);
                switch(splits[0])
                {
                    case "forward":
                        depth += magnitude;
                        horizontal += magnitude * aim;
                        break;
                    case "down":
                        aim += magnitude;
                        break;
                    case "up":
                        aim -= magnitude;
                        break;
                    default:
                        Console.WriteLine("Input not coded!");
                        break;
                }
            }
            Console.WriteLine($"Final depth: {depth}. Final horizontal position: {horizontal}. Product: {depth * horizontal}");
        }
    }
}

/* Part 1:
 *            string[] lines = InputReader.ReadLines("input.txt");
            int horizontal = 0;
            int depth = 0;
            foreach(string line in lines)
            {
                string[] splits = line.Split(' ');
                int magnitude = int.Parse(splits[1]);
                switch(splits[0])
                {
                    case "forward":
                        horizontal += magnitude;
                        break;
                    case "down":
                        depth += magnitude;
                        break;
                    case "up":
                        depth -= magnitude;
                        break;
                    default:
                        Console.WriteLine("Input not coded!");
                        break;
                }
            }
            Console.WriteLine($"Final depth: {depth}. Final horizontal position: {horizontal}. Product: {depth * horizontal}");
*/
