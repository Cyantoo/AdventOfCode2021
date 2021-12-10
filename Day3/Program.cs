using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = InputReader.ReadLines("input.txt");
            List<string> oxygen_candidates = lines.ToList();
            List<string> co2_candidates = lines.ToList();
            int current_bit = 0;
            while (oxygen_candidates.Count > 1) // loop for oxygen
            {
                int count_0 = 0;
                int count_1 = 0;
                foreach (string oxygen_candidate in oxygen_candidates)
                {
                    if (oxygen_candidate[current_bit] == '0') count_0++;
                    else count_1++;
                }
                if (count_0 <= count_1)
                {
                    oxygen_candidates = Remove_number_at_bit(oxygen_candidates, current_bit, '0');
                }
                else
                {
                    oxygen_candidates = Remove_number_at_bit(oxygen_candidates, current_bit, '1');
                }
                current_bit++;
            }
            string oxygen = oxygen_candidates[0];
            int decimal_oxygen = Convert.ToInt32(oxygen, 2);
            current_bit = 0;
            while (co2_candidates.Count > 1) // loop for co2
            {
                int count_0 = 0;
                int count_1 = 0;
                foreach (string co2_candidate in co2_candidates)
                {
                    if (co2_candidate[current_bit] == '0') count_0++;
                    else count_1++;
                }
                if (count_0 <= count_1)
                {
                    co2_candidates = Remove_number_at_bit(co2_candidates, current_bit, '1');
                }
                else
                {
                    co2_candidates = Remove_number_at_bit(co2_candidates, current_bit, '0');
                }
                current_bit++;
            }
            string co2 = co2_candidates[0];
            int decimal_co2 = Convert.ToInt32(co2, 2);
            Console.WriteLine($"Oxygen: binary : {oxygen}; decimal: {decimal_oxygen}. \nCo2 : binary : {co2}; decimal: {decimal_co2}.\nProduct: {decimal_oxygen * decimal_co2}.");

        }

        static private List<string> Remove_number_at_bit(List<string> list_candidates, int bit, char number_to_remove)
        {
            var list_result = new List<string>(list_candidates);
            foreach (string candidate in list_candidates)
            {
                if (candidate[bit] == number_to_remove) list_result.Remove(candidate);
            }
            return list_result;
        }
    }
}



/* Part 1
 * string[] lines = InputReader.ReadLines("input.txt");
            string gamma = "";
            string epsilon = "";
            for (int j = 0; j < lines[0].Length; j++)
            {
                int count_0 = 0;
                int count_1 = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i][j] == '0') count_0++;
                    else count_1++;
                }
                if(count_0 < count_1)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            int decimal_gamma = Convert.ToInt32(gamma, 2);
            int decimal_epsilon = Convert.ToInt32(epsilon, 2);
            Console.WriteLine($"gamma: binary : {gamma}; decimal: {decimal_gamma}. \nEpsilon : binary : {epsilon}; decimal: {decimal_epsilon}.\nProduct: {decimal_epsilon*decimal_gamma}.");
*/
