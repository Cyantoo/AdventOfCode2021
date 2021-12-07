using System;
using System.IO;

namespace Utils
{
    public class InputReader
    {
        public static string[] ReadLines(string filename)
        {
            string projectDirectory = GetProjectDirectory();
            string[] lines = File.ReadAllLines(projectDirectory + @"\" + filename);
            return lines;

        }

        public static string ReadFirstLine(string filename)
        {
            string projectDirectory = GetProjectDirectory();
            string[] lines = File.ReadAllLines(projectDirectory + @"\" + filename);
            return lines[0];

        }
        public static int[] ReadIntsFromFirstLine(string filename, char separator = ',')
        {
            string projectDirectory = GetProjectDirectory();
            string[] lines = File.ReadAllLines(projectDirectory + @"\" + filename);
            return Array.ConvertAll(lines[0].Split(separator), s => int.Parse(s));

        }

        public static int[] ReadInts(string filename)
        {
            string projectDirectory = GetProjectDirectory();
            string[] lines = File.ReadAllLines(projectDirectory + @"\" + filename);
            int[] lines_ints = Array.ConvertAll(lines, s => int.Parse(s));
            return lines_ints;
        }

        private static string GetProjectDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }

    }
}
