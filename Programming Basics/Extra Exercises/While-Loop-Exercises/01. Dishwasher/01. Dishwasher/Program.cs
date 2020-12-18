using System;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            double botleChemicalCount = double.Parse(Console.ReadLine());
            double totalAmount = botleChemicalCount * 750;
            int count = 0;
            string comand = Console.ReadLine();
            int platsCount = 0;
            int panCount = 0;
            bool end = false;
            while (true)
            {
                if (comand == "End")
                {
                    end = true;
                    break;
                }
                double mlNeeded = 0;
                int dishesCount = int.Parse(comand);
                count++;
                if (count % 3 == 0)
                {
                    mlNeeded = dishesCount * 15;
                    panCount += dishesCount;
                }
                else
                {
                    mlNeeded = dishesCount * 5;
                    platsCount += dishesCount;
                }
                totalAmount -= mlNeeded;
                if (totalAmount < 0)
                {
                    break;
                }
                comand = Console.ReadLine();
            }
            if (end)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{platsCount} dishes and {panCount} pots were washed.");
                Console.WriteLine($"Leftover detergent {totalAmount} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(totalAmount)} ml. more necessary!");
            }
        }
    }
}
