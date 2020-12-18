using System;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalAmount = double.Parse(Console.ReadLine());
            double moneyGathered = 0;
            string comand = Console.ReadLine();
            int transCount = 1;
            double cardPay = 0;
            double cashPay = 0;
            int cardCount = 0;
            int cashCount = 0;
            bool end = false;
            while (true)
            {
                if (comand == "End")
                {
                    end = true;
                    break;
                }
                double price = double.Parse(comand);
                if (transCount % 2 == 0)
                {
                    if (price < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cardCount++;
                        cardPay += price;
                        moneyGathered += price;
                    }
                }
                else
                {
                    if (price > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cashCount++;
                        cashPay += price;
                        moneyGathered += price;
                    }
                }
                if (moneyGathered >= totalAmount)
                {
                    break;
                }
                comand = Console.ReadLine();
                transCount++;
            }
            if (end)
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
            else
            {
                Console.WriteLine($"Average CS: {cashPay / cashCount:f2}");
                Console.WriteLine($"Average CC: {cardPay / cardCount:f2}");
            }
        }
    }
}
