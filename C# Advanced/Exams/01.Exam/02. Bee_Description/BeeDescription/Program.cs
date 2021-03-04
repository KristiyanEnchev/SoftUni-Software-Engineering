using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp59
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int beerow = 0;
            int beeCol = 0;

            for (int row = 0; row < n; row++)
            {
                string curr = Console.ReadLine();

                for (int col = 0; col < curr.Length; col++)
                {
                    matrix[row, col] = curr[col];
                    if (matrix[row, col] == 'B')
                    {
                        beerow = row;
                        beeCol = col;
                    }
                }
            }

            int flowers = 0;
            string input = Console.ReadLine();
            while (input != "End")
            {
                matrix[beerow, beeCol] = '.';
                beerow = MoveRow(beerow, input);
                beeCol = MoveCol(beeCol, input);

                if (!IsValid(beerow, beeCol, n,n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beerow, beeCol] == 'f')
                {
                    flowers++;
                }

                if (matrix[beerow, beeCol] == 'O')
                {
                    matrix[beerow, beeCol] = '.';
                    beerow = MoveRow(beerow, input);
                    beeCol = MoveCol(beeCol, input);

                    if (!IsValid(beerow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beerow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                }

                matrix[beerow, beeCol] = 'B';
                input = Console.ReadLine();
            }

            if ( flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsValid(int row, int col, int rows, int cols)
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

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }

            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }
        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }

            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
    }
}
