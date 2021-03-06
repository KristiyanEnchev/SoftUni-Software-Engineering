using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            string comand = Console.ReadLine();
            while (comand != "Bloom Bloom Plow")
            {
                int[] cordinates = comand
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int flowerRow = cordinates[0];
                int flowerCol = cordinates[1];

                if (!IsPositionValid(flowerRow, flowerCol, size[0], size[1]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    comand = Console.ReadLine();
                    continue;
                }

                for (int row = 0; row < size[1]; row++)
                {
                    matrix[row, flowerCol] += 1;
                }
                for (int col = 0; col < size[0]; col++)
                {
                    if (col == flowerCol)
                    {
                        continue;
                    }
                    matrix[flowerRow, col] += 1;
                }

                comand = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
