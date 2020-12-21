using System;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int sierisCount = int.Parse(Console.ReadLine());
            if (sierisCount < 1 || sierisCount > 10)
            {
                sierisCount = int.Parse(Console.ReadLine());
            }
            double totalPrice = 0;
            for (int i = 1; i <= sierisCount; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                if (name == "Thrones")
                {
                    price /= 2;
                }
                else if (name == "Lucifer")
                {
                    price *= 0.60;
                }
                else if (name == "Protector")
                {
                    price *= 0.70;
                }
                else if (name == "TotalDrama")
                {
                    price *= 0.80;
                }
                else if (name == "Area")
                {
                    price *= 0.90;
                }
                totalPrice += price;
            }
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You bought all the series and left with {budget - totalPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {totalPrice - budget:f2} lv. more to buy the series!");
            }
        }
    }
}
