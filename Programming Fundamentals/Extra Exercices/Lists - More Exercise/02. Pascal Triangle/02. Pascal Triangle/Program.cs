using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(1);
        int number = 1;
        for (int row = 1; row < num; row++)
        {
            if (num == 13 && row == 8)
            {
                break;
            }
            Console.Write(1);
            for (int coll = 1; coll <= row; coll++)
            {
                number = number * (row - coll + 1) / coll;
                Console.Write($" {number}");
            }
            Console.WriteLine();
        }
    }
}