using System;
using System.Xml.Schema;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string flavor = Console.ReadLine();
            string type = Console.ReadLine();
            int orderCount = int.Parse(Console.ReadLine());

            double watermelonPrice = 0;
            double mangoPrice = 0;
            double pineapplePrice = 0;
            double raspberryPrice = 0;
            double total = 0;

            switch (flavor)
            {
                case "Watermelon":
                    switch (type)
                    {
                        case "small":
                            watermelonPrice = 2 * 56;
                            total = watermelonPrice * orderCount;
                            break;
                        case "big":
                            watermelonPrice = 5 * 28.70;
                            total = watermelonPrice * orderCount;
                            break;
                    }
                    break;
                case "Mango":
                    switch (type)
                    {
                        case "small":
                            mangoPrice = 2 * 36.66;
                            total = mangoPrice * orderCount;
                            break;
                        case "big":
                            mangoPrice = 5 * 19.60;
                            total = mangoPrice * orderCount;
                            break;
                    }
                    break;
                case "Pineapple":
                    switch (type)
                    {
                        case "small":
                            pineapplePrice = 2 * 42.10;
                            total = pineapplePrice * orderCount;
                            break;
                        case "big":
                            pineapplePrice = 5 * 24.80;
                            total = pineapplePrice * orderCount;
                            break;
                    }
                    break;
                case "Raspberry":
                    switch (type)
                    {
                        case "small":
                            raspberryPrice = 2 * 20;
                            total = raspberryPrice * orderCount;
                            break;
                        case "big":
                            raspberryPrice = 5 * 15.20;
                            total = raspberryPrice * orderCount;
                            break;
                    }
                    break;
            }

            double totalWithDiscount = 0;

            if (total >= 400 && total <= 1000)
            {
                totalWithDiscount = total * 0.85;
            }
            else if (total > 1000)
            {
                totalWithDiscount = total * 0.50;
            }
            else
            {
                totalWithDiscount = total;
            }
            Console.WriteLine($"{totalWithDiscount:f2} lv.");
        }
    }
}
