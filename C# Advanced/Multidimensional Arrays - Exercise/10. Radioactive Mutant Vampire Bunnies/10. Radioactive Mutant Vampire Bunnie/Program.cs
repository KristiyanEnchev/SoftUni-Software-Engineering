using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] demensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int n = demensions[0];
            int m = demensions[1];
            char[,] field = new char[n, m];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int col = 0; col < m; col++)
                {
                    field[row, col] = rowData[col];

                    if (field[row, col] == "P")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;

            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }

                if (!IsValidCell(newPlayerRow, newPlayerCol, n, m))
                {
                    isWon = true;
                    field[playerRow, playerCol] = '.';
                }
                else if (field[newPlayerRow, newPlayerCol] == '.')
                {
                    field[playerRow, playerCol] = '.';
                    field[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;

                    if (field[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (field[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    field[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> bunniesCoordinates = GetBunniesCoordinates(field);
                SpreadBunnies(bunniesCoordinates, field);

                if (isDead || isWon)
                {
                    break;
                }

                PrintField(field);

                string res = "";

                if (isWon)
                {
                    res += "won"
                }
                else
                {
                    res += "dead";
                }

                res += $": {playerRow} {playerCol}";
                Console.WriteLine(res);
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] field)
        {
            foreach (int[] bunnyCoordinates in bunniesCoordinates)
            {
                int row = bunniesCoordinates[0];
                int col = bunniesCoordinates[1];

                SpreadBunnies(row - 1, col, field);
                SpreadBunnies(row + 1, col, field);
                SpreadBunnies(row, col - 1, field);
                SpreadBunnies(row, col + 1, field);
            }
        }

        private static void SpreadBunnies(int v, int col, char[,] field)
        {
            int rowLenght = field.GetLength(0);
            int colLenght = field.GetLength(1);

            if (IsValidCell(row - 1, col, rowLenght, colLenght))
            {
                field[row - 1, col] = 'B';
            }
        }

        private static bool IsValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }

        private static List<int[]> GetBunniesCoordinates(char[,] field)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == "B")
                    {
                        bunniesCoordinates.Add(new int[] { row, col })
                    }
                }
            }
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.WriteLine(field[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
