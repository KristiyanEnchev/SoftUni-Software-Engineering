using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixNumber = int.Parse(Console.ReadLine());

            Matrix(matrixNumber);
        }

        public static void Matrix(int matrix)
        {
            for (int roll = 0; roll < matrix; roll++)
            {
                for (int coll = 0; coll < matrix; coll++)
                {
                    Console.Write($"{matrix} ");
                }
                Console.WriteLine();
            }
        }
    }
}
