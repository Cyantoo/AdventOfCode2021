using System;
using System.Collections.Generic;
using Utils;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            MainStuff();
        }

        private static void MainStuff()
        {
            string[] lines = InputReader.ReadLines("input.txt");
            int sum = 0;
            foreach (string line in lines)
            {
                string[] output = line.Split(" | ");
                Dictionary<int, HashSet<char>> mapping = new();

                var digits = output[0].Split(' ');
                List<string> remaining_digits = new(digits);
                foreach (string digit in digits)
                {
                    if (digit.Length == 2)
                    {
                        mapping.Add(1, new HashSet<char>(digit));
                        remaining_digits.Remove(digit);
                    }
                    if (digit.Length == 4)
                    {
                        mapping.Add(4, new HashSet<char>(digit));
                        remaining_digits.Remove(digit);
                    }
                    if (digit.Length == 3)
                    {
                        mapping.Add(7, new HashSet<char>(digit));
                        remaining_digits.Remove(digit);
                    }
                    if (digit.Length == 7)
                    {
                        mapping.Add(8, new HashSet<char>(digit));
                        remaining_digits.Remove(digit);
                    }
                }
                List<string> current_digits = new(remaining_digits);
                foreach (string digit in current_digits)
                {
                    if (digit.Length == 5)
                    {
                        if (ContainsEveryLetter(digit, mapping[1]))
                        {
                            mapping.Add(3, new HashSet<char>(digit));
                            remaining_digits.Remove(digit);
                        }
                    }
                    if (digit.Length == 6)
                    {
                        if (ContainsEveryLetter(digit, mapping[4]))
                        {
                            mapping.Add(9, new HashSet<char>(digit));
                            remaining_digits.Remove(digit);
                        }
                    }
                }
                current_digits = new(remaining_digits);
                foreach (string digit in current_digits)
                {
                    if (digit.Length == 6)
                    {
                        if (ContainsEveryLetter(digit, SetDifference(mapping[4], mapping[1])))
                        {
                            mapping.Add(6, new HashSet<char>(digit));
                            remaining_digits.Remove(digit);
                        }
                    }
                }
                current_digits = new(remaining_digits);
                foreach (string digit in current_digits)
                {
                    if (digit.Length == 6)
                    {
                        mapping.Add(0, new HashSet<char>(digit));
                        remaining_digits.Remove(digit);
                    }
                    else
                    {
                        if (ContainsEveryLetter(digit, SetDifference(mapping[1], mapping[6])))
                        {
                            mapping.Add(2, new HashSet<char>(digit));
                            remaining_digits.Remove(digit);
                        }
                    }
                }
                mapping.Add(5, new HashSet<char>(remaining_digits[0]));
                // Decode and sum output
                string result = "";
                foreach (string digit in output[1].Split(' '))
                {
                    result += ReverseDictionary(mapping, new HashSet<char>(digit));
                }
                //Console.WriteLine(result);
                sum += int.Parse(result);

            }
            Console.WriteLine(sum);
        }

        private static bool ContainsEveryLetter(string big_string, IEnumerable<char> small_string)
        {
            bool result = true;
            foreach (char letter in small_string)
            {
                if (!big_string.Contains(letter)) result = false;
            }
            return result;
        }

        private static HashSet<char> SetDifference(HashSet<char> string1, HashSet<char> string2)
        {
            HashSet<char> result = new(string1);
            foreach (char letter in string2)
            {
                result.Remove(letter);
            }
            return result;
        }

        private static int ReverseDictionary(Dictionary<int, HashSet<char>> mapping, HashSet<char> value)
        {
            foreach (int a in mapping.Keys)
            {
                if (mapping[a].SetEquals(value)) return a;
            }
            return -100;
        }
    }
}

/* Part 1 :
 *         static void Main(string[] args)
        {
            string[] lines = InputReader.ReadLines("input.txt");
            int count = 0;
            foreach(string line in lines)
            {
                string[] output = line.Split(" | ");
                foreach(string digit in output[1].Split(' '))
                {
                    if (digit.Length == 2 || digit.Length == 4 || digit.Length == 3 || digit.Length == 7) count++;
                }
            }
            Console.WriteLine(count);
*/
