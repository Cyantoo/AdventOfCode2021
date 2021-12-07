using System;
using System.Linq;
using Utils;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] crab_positions = InputReader.ReadIntsFromFirstLine("input.txt");
            int? best_horizontal_position = new int?();
            int? fuel_at_best_position = new int?();
            for(int horizontal_position = crab_positions.Min(); horizontal_position <= crab_positions.Max(); horizontal_position++)
            {
                int fuel_consumed = crab_positions.Select(
                    i =>
                    {
                        int distance = Math.Abs(i - horizontal_position);
                        return distance * (distance + 1) / 2;
                    }
                    ).Sum();
                best_horizontal_position = best_horizontal_position ?? horizontal_position;
                fuel_at_best_position = fuel_at_best_position ?? fuel_consumed;
                if(fuel_consumed < fuel_at_best_position)
                {
                    fuel_at_best_position = fuel_consumed;
                    best_horizontal_position = horizontal_position;
                }
            }
            Console.WriteLine($"Best position: {best_horizontal_position}. Fuel consumed there: {fuel_at_best_position}");

        }
    }
}

/* Part 1:
 * int[] crab_positions = InputReader.ReadIntsFromFirstLine("input.txt");
            int? best_horizontal_position = new int?();
            int? fuel_at_best_position = new int?();
            for(int horizontal_position = crab_positions.Min(); horizontal_position <= crab_positions.Max(); horizontal_position++)
            {
                int fuel_consumed = crab_positions.Select(i => Math.Abs(i- horizontal_position)).Sum();
                best_horizontal_position = best_horizontal_position ?? horizontal_position;
                fuel_at_best_position = fuel_at_best_position ?? fuel_consumed;
                if(fuel_consumed < fuel_at_best_position)
                {
                    fuel_at_best_position = fuel_consumed;
                    best_horizontal_position = horizontal_position;
                }
            }
            Console.WriteLine($"Best position: {best_horizontal_position}. Fuel consumed there: {fuel_at_best_position}");
*/
