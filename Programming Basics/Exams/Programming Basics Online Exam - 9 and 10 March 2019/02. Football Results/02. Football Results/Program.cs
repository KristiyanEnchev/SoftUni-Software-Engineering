using System;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            int won = 0;
            int loose = 0;
            int draw = 0;
            string firstResult = Console.ReadLine();
            int num = firstResult[0];
            int num2 = firstResult[2];
            if (num > num2)
            {
                won++;
            }
            else if (num2 > num)
            {
                loose++;
            }
            else
            {
                draw++;
            }
            string thurdResult = Console.ReadLine();
            int numm = thurdResult[0];
            int numm2 = thurdResult[2];
            if (numm > numm2)
            {
                won++;
            }
            else if (numm2 > numm)
            {
                loose++;
            }
            else
            {
                draw++;
            }
            string secondResult = Console.ReadLine();
            int num1 = secondResult[0];
            int num3 = secondResult[2];
            if (num1 > num3)
            {
                won++;
            }
            else if (num3 > num1)
            {
                loose++;
            }
            else
            {
                draw++;
            }
            Console.WriteLine($"Team won {won} games.");
            Console.WriteLine($"Team lost {loose} games.");
            Console.WriteLine($" Drawn games: {draw}");
        }
    }
}
