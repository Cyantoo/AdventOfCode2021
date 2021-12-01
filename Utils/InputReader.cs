using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class InputReader
    {
        public static int[] ReadInts(string filename)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            Console.WriteLine(projectDirectory);
            string[] lines = File.ReadAllLines(projectDirectory + @"\"+filename);
            int[] lines_ints = Array.ConvertAll(lines, s => int.Parse(s));
            return lines_ints;
        }
    }
}
