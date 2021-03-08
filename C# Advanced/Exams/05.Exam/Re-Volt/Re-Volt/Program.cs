using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int comandcount = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }


            int count = 0;

            for (int i = 0; i < comandcount; i++)
            {
                string comand = Console.ReadLine();

                int previusRow = startRow;
                int previusCol = startCol;

                matrix[startRow, startCol] = '-';

                startRow = MoveRow(startRow, comand, size);
                startCol = MoveCol(startCol, comand, size);

                if (matrix[startRow, startCol] == 'F')
                {
                    matrix[startRow, startCol] = 'f';
                    Console.WriteLine("Player won!");
                    break;
                }

                if (matrix[startRow, startCol] == 'T')
                {
                    startRow = previusRow;
                    startCol = previusCol;
                }

                if (matrix[startRow, startCol] == 'B')
                {
                    startRow = MoveRow(startRow, comand, size);
                    startCol = MoveCol(startCol, comand, size);

                    if (matrix[startRow, startCol] == 'F')
                    {
                        matrix[startRow, startCol] = 'f';
                        Console.WriteLine("Player won!");
                        break;
                    }

                    if (matrix[startRow, startCol] == 'T')
                    {
                        startRow = previusRow;
                        startCol = previusCol;
                    }
                }

                matrix[startRow, startCol] = 'f';
                count++;
            }

            if (count == comandcount)
            {
                Console.WriteLine("Player lost!");
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
        private static int MoveRow(int startRow, string comand, int size1)
        {
            if (comand == "up")
            {
                if (IsRowValid(startRow, size1))
                {
                    return startRow - 1;
                }

                return size1 - 1;
            }
            if (comand == "down")
            {
                if (IsRowValid(startRow, size1))
                {
                    return startRow + 1;
                }

                return 0;
            }

            return startRow;
        }

        private static int MoveCol(int startCol, string comand, int size2)
        {
            if (comand == "left")
            {
                if (IsColValid(startCol, size2))
                {
                    return startCol - 1;
                }

                return size2 - 1;
            }
            if (comand == "right")
            {
                if (IsRowValid(startCol, size2))
                {
                    return startCol + 1;
                }

                return 0;
            }

            return startCol;
        }

        public static bool IsRowValid(int row, int rows)
        {
            if (row <= 0 || row >= rows - 1)
            {
                return false;
            }

            return true;
        }
        public static bool IsColValid(int col, int cols)
        {
            if (col <= 0 || col >= cols - 1)
            {
                return false;
            }

            return true;
        }
    }
}
