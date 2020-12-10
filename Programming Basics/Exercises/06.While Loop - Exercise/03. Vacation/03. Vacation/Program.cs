using System;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            double moneyCount = double.Parse(Console.ReadLine());
            int dayCount = 0;
            int spendig = 0;
            while (moneyCount < excursionPrice && spendig < 5)
            {
                string function = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                dayCount++;
                if (function == "spend")
                {
                    moneyCount -= money;
                    spendig += 1;
                    if (moneyCount <= 0)
                    {
                        moneyCount = 0;
                        continue;
                    }
                }
                if (function == "save")
                {
                    moneyCount += money;
                    spendig = 0;
                }
            }
            if (spendig == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine($"{dayCount}");
            }
            if (moneyCount >= excursionPrice)
            {
                Console.WriteLine($"You saved the money for {dayCount} days.");
            }
        }
    }
}
