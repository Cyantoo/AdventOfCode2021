using System;

namespace Day5
{
    class VentDiagram
    {
        private int[,] ventsPerCell;
        private int size;
        public VentDiagram(int diagram_size = 1000)
        {
            size = diagram_size;
            ventsPerCell = new int[size, size];
        }

        public void PrintResult()
        {
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (ventsPerCell[i, j] > 1) result++;
                }
            }
            //Print2Darray(ventsPerCell);
            Console.WriteLine(result);
        }

        public void ProcessLine(string line)
        {
            string[] points = line.Replace(" ", "").Split("->");
            int[] A = Array.ConvertAll(points[0].Split(','), s => int.Parse(s));
            int[] B = Array.ConvertAll(points[1].Split(','), s => int.Parse(s));
            //Console.WriteLine($"{A[0]},{A[1]}->{B[0]},{B[1]}");
            if (A[0] == B[0])
            {
                int start = A[1];
                int end = B[1];
                if (A[1] > B[1])
                {
                    start = B[1];
                    end = A[1];
                }
                for (int i = start; i <= end; i++)
                {
                    ventsPerCell[A[0], i]++;
                }
            }
            else if (A[1] == B[1])
            {
                int start = A[0];
                int end = B[0];
                if (A[0] > B[0])
                {
                    start = B[0];
                    end = A[0];
                }
                for (int i = start; i <= end; i++)
                {
                    ventsPerCell[i, A[1]]++;
                }
            }
            else // Diagonal case
            {
                int direction_x = A[0] < B[0] ? 1 : -1;
                int direction_y = A[1] < B[1] ? 1 : -1;

                for (int i = 0; i <= Math.Abs(A[0] - B[0]); i++)
                {
                    ventsPerCell[A[0] + direction_x * i, A[1] + direction_y * i]++;
                }
            }
            //Print2Darray(ventsPerCell);
        }
        private void Print2Darray(int[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}
