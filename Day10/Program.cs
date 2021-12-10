using System;
using System.Collections.Generic;
using Utils;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = InputReader.ReadLines("input.txt");
            List<long> scores = new();
            foreach(string line in lines)
            {
                Stack<char> openChunks = new();
                foreach(char current in line)
                {
                    if(current == '(' || current == '[' || current == '{' || current == '<')
                    {
                        openChunks.Push(current);
                    }
                    else
                    {
                        char last = openChunks.Pop();
                        switch (current)
                        {
                            case ')':
                                if (last != '(')
                                {
                                    goto EndOfLine;
                                }
                                break;
                            case '}':
                                if (last != '{')
                                {
                                    goto EndOfLine;
                                }
                                break;
                            case ']':
                                if (last != '[')
                                {
                                    goto EndOfLine;
                                }
                                break;
                            case '>':
                                if (last != '<')
                                {
                                    goto EndOfLine;
                                }
                                break;
                        }
                    }
                    
                }
                // Here we have an incomplete line
                long completionScore = 0;
                foreach(char symbol in openChunks)
                {
                    completionScore *= 5;
                    switch (symbol)
                    {
                        case '(': completionScore += 1; break;
                        case '[': completionScore += 2; break;
                        case '{': completionScore += 3; break;
                        case '<': completionScore += 4; break;

                    }
                }
                Console.WriteLine(completionScore);
                scores.Add(completionScore);
            EndOfLine:;
            }
            scores.Sort();
            Console.WriteLine(scores[scores.Count/2]);
        }
    }
}

/* Part 1 :
 *             string[] lines = InputReader.ReadLines("input.txt");
            int score = 0;
            foreach(string line in lines)
            {
                Stack<char> openChunks = new();
                foreach(char current in line)
                {
                    if(current == '(' || current == '[' || current == '{' || current == '<')
                    {
                        openChunks.Push(current);
                    }
                    else
                    {
                        char last = openChunks.Pop();
                        switch (current)
                        {
                            case ')':
                                if (last != '(')
                                {
                                    score += 3;
                                    goto EndOfLine;
                                }
                                break;
                            case '}':
                                if (last != '{')
                                {
                                    score += 1197;
                                    goto EndOfLine;
                                }
                                break;
                            case ']':
                                if (last != '[')
                                {
                                    score += 57;
                                    goto EndOfLine;
                                }
                                break;
                            case '>':
                                if (last != '<')
                                {
                                    score += 25137;
                                    goto EndOfLine;
                                }
                                break;
                        }
                    }
                    
                }
            EndOfLine:;
            }
            Console.WriteLine(score);*/
