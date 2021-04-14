using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int charRow = 0;
            int charCol = 0;

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'M')
                    {
                        charRow = row;
                        charCol = col;
                    }
                }
            }

            while (lives > 0)
            {
                string[] input = Console.ReadLine().Split();
                string moveCommand = input[0];
                int mobSpawnRow = int.Parse(input[1]);
                int mobSpawnCol = int.Parse(input[2]);

                SpawnMobs(matrix, mobSpawnRow, mobSpawnCol);
                int currentRow = charRow;
                int currentCol = charCol;

                matrix[charRow, charCol] = '-';
                charRow = MoveRow(charRow, moveCommand);
                charCol = MoveCol(charCol, moveCommand);

                lives -= 1;
                if (!IsPositionValid(charRow, charCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    charRow = currentRow;
                    charCol = currentCol;
                    continue;
                }

                if (matrix[charRow, charCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        //matrix[charRow, charCol] = 'X';
                        //Console.WriteLine($"Mario died at {charRow};{charCol}.");
                        break;
                    }

                    matrix[charRow, charCol] = 'M';
                }

                if (matrix[charRow, charCol] == 'P')
                {
                    matrix[charRow, charCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }

                //matrix[charRow, charCol] = 'M';
            }

            if (lives <= 0)
            {
                matrix[charRow, charCol] = 'X';
                Console.WriteLine($"Mario died at {charRow};{charCol}.");
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void SpawnMobs(char[,] matrix, int spawnRow, int spawnCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == spawnRow && col == spawnCol)
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "W")
            {
                return row - 1;
            }
            if (movement == "S")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "A")
            {
                return col - 1;
            }
            if (movement == "D")
            {
                return col + 1;
            }

            return col;
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
