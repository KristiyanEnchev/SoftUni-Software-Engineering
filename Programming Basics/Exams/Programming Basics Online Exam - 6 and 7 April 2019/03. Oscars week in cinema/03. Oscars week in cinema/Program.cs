using System;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            string type = Console.ReadLine();
            double ticketCount = double.Parse(Console.ReadLine());
            double price = 0;
            switch (movieName)
            {
                case "A Star Is Born":
                    switch (type)
                    {
                        case "normal":
                            price = 7.50;
                            break;
                        case "luxury":
                            price = 10.50;
                            break;
                        case "ultra luxury":
                            price = 13.50;
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (type)
                    {
                        case "normal":
                            price = 7.35;
                            break;
                        case "luxury":
                            price = 9.45;
                            break;
                        case "ultra luxury":
                            price = 12.75;
                            break;
                    }
                    break;
                case "Green Book":
                    switch (type)
                    {
                        case "normal":
                            price = 8.15;
                            break;
                        case "luxury":
                            price = 10.25;
                            break;
                        case "ultra luxury":
                            price = 13.25;
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (type)
                    {
                        case "normal":
                            price = 8.75;
                            break;
                        case "luxury":
                            price = 11.55;
                            break;
                        case "ultra luxury":
                            price = 13.95;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"{movieName} -> {price * ticketCount:f2} lv.");
        }
    }
}
