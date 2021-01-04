using System;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            double totalCoins = 0;
            while (true)
            {
                if (comand == "Start")
                {
                    while (true)
                    {
                        string product = Console.ReadLine();
                        if (product == "End")
                        {
                            Console.WriteLine($"Change: {totalCoins:f2}");
                            Environment.Exit(0);
                        }
                        switch (product)
                        {
                            case "Nuts":
                                if (totalCoins - 2.0 >= 0)
                                {
                                    Console.WriteLine($"Purchased {product.ToLower()}");
                                    totalCoins -= 2.0;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                                break;
                            case "Water":
                                if (totalCoins - 0.7 >= 0)
                                {
                                    Console.WriteLine($"Purchased {product.ToLower()}");
                                    totalCoins -= 0.7;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                                break;
                            case "Crisps":
                                if (totalCoins - 1.5 >= 0)
                                {
                                    Console.WriteLine($"Purchased {product.ToLower()}");
                                    totalCoins -= 1.5;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                                break;
                            case "Soda":
                                if (totalCoins - 0.8 >= 0)
                                {
                                    Console.WriteLine($"Purchased {product.ToLower()}");
                                    totalCoins -= 0.8;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                                break;
                            case "Coke":
                                if (totalCoins - 1.0 >= 0)
                                {
                                    Console.WriteLine($"Purchased {product.ToLower()}");
                                    totalCoins -= 1.0;
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, not enough money");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid product");
                                break;
                        }

                    }
                }
                double coins = double.Parse(comand);
                switch (coins)
                {
                    case 0.1:
                        totalCoins += coins;
                        break;
                    case 0.2:
                        totalCoins += coins;
                        break;
                    case 0.5:
                        totalCoins += coins;
                        break;
                    case 1.0:
                        totalCoins += coins;
                        break;
                    case 2.0:
                        totalCoins += coins;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        break;
                }
                comand = Console.ReadLine();
            }
        }
    }
}
