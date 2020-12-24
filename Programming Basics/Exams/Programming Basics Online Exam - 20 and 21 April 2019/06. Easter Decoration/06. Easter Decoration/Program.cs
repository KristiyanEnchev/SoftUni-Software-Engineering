using System;

namespace ConsoleApp31
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            double basket = 1.50;
            double wreath = 3.80;
            double chocolateBunny = 7.00;
            double endPrice = 0;
            for (int i = 1; i <= peopleCount; i++)
            {
                int itemsCount = 0;
                double totalPrice = 0;
                bool finish = false;
                while (true)
                {
                    string item = Console.ReadLine();
                    if (item == "Finish")
                    {
                        finish = true;
                        break;
                    }
                    itemsCount++;
                    if (item == "basket")
                    {
                        totalPrice += basket;
                    }
                    else if (item == "wreath")
                    {
                        totalPrice += wreath;
                    }
                    else if (item == "chocolate bunny")
                    {
                        totalPrice += chocolateBunny;
                    }
                }
                if (itemsCount % 2 == 0)
                {
                    totalPrice *= 0.80;
                }
                endPrice += totalPrice;
                if (finish)
                {
                    Console.WriteLine($"You purchased {itemsCount} items for {totalPrice:f2} leva.");
                }
            }
            Console.WriteLine($"Average bill per client is: {endPrice / peopleCount:f2} leva.");
        }
    }
}
