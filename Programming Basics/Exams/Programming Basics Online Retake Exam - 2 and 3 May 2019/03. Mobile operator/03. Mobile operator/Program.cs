using System;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeForContract = Console.ReadLine();
            string typeOfContract = Console.ReadLine();
            string internet = Console.ReadLine();
            int mounths = int.Parse(Console.ReadLine());
            double price = 0;
            if (timeForContract == "one")
            {
                switch (typeOfContract)
                {
                    case "Small":
                        price = 9.98;
                        break;
                    case "Middle":
                        price = 18.99;
                        break;
                    case "Large":
                        price = 25.98;
                        break;
                    case "ExtraLarge":
                        price = 35.99;
                        break;
                }
            }
            else if (timeForContract == "two")
            {
                switch (typeOfContract)
                {
                    case "Small":
                        price = 8.58;
                        break;
                    case "Middle":
                        price = 17.09;
                        break;
                    case "Large":
                        price = 23.59;
                        break;
                    case "ExtraLarge":
                        price = 31.79;
                        break;
                }
            }
            if (internet == "yes")
            {
                if (price <= 10.00)
                {
                    price += 5.50;
                }
                else if (price <= 30.00)
                {
                    price += 4.35;
                }
                else if (price > 30)
                {
                    price += 3.85;
                }
            }
            if (timeForContract == "two")
            {
                price *= 0.9625;
            }
            Console.WriteLine($"{price * mounths:f2} lv.");
        }
    }
}
