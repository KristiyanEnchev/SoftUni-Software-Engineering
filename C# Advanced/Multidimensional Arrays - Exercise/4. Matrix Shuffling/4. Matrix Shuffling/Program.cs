using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dementions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dementions[0];
            int m = dementions[1];

            string[,] matrix = new string[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ");

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            while (true)
            {
            string comand = Console.ReadLine();

                if (comand == "END")
                {
                    break;
                }
                string[] comandData = comand.Split(" ");

                if (comandData.Length != 5 || comandData[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowOne = int.Parse(comandData[1]);
                int colOne = int.Parse(comandData[2]);
                int rowTwo = int.Parse(comandData[3]);
                int colTwo = int.Parse(comandData[4]);

                bool isValidOne = rowOne >= 0 && rowOne < n && colOne >= 0 && colOne < m;
                //bool isOutOfMatrix = rowOne < 0 || rowOne >= n || colOne < 0 || colOne >= n;
                bool isValidTwo = rowTwo >= 0 && rowTwo < n && colTwo >= 0 && colTwo < m;

                if (!isValidOne || !isValidTwo)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string valueOne = matrix[rowOne, colOne];
                string valueTwo = matrix[rowTwo, colTwo];

                matrix[rowOne, colOne] = valueTwo;
                matrix[rowTwo, colTwo] = valueOne;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < m; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
