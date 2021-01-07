using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int pour = 0;
            int numberOfPours = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfPours; i++)
            {
                int litersToAdd = int.Parse(Console.ReadLine());
                if (litersToAdd <= capacity)
                {
                    capacity -= litersToAdd;
                    pour += litersToAdd;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(pour);
        }
    }
}
