using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodQuantity = 0;

            while (foodQuantity < 10)
            {
                matrix[snakeRow, snakeCol] = '.';
                string comand = Console.ReadLine();
                snakeRow = MoveRow(snakeRow, comand);
                snakeCol = MoveCol(snakeCol, comand);

                if (!IsPositionValid(snakeRow, snakeCol, n, n))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                    matrix[snakeRow, snakeCol] = 'S';
                    continue;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {

                    matrix[snakeRow, snakeCol] = '.';
                    int layerRow = 0;
                    int layerCol = 0;

                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                layerRow = row;
                                layerCol = col;
                            }
                        }
                    }

                    snakeRow = layerRow;
                    snakeCol = layerCol;
                }

                matrix[snakeRow, snakeCol] = 'S';

            }

            if (foodQuantity >= 10)
            {
                Console.WriteLine($"You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodQuantity}");
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
