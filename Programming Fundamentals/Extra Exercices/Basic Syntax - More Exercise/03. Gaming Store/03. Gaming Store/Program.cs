using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp55
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string comand = Console.ReadLine();
            double price = 0;
            double budget = balance;
            double totalSpend = 0;
            while (comand != "Game Time")
            {
                if (comand == "OutFall 4")
                {
                    price = 39.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (comand == "CS: OG")
                {
                    price = 15.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (comand == "Zplinter Zell")
                {
                    price = 19.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (comand == "Honored 2")
                {
                    price = 59.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (comand == "RoverWatch")
                {
                    price = 29.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }

                }
                else if (comand == "RoverWatch Origins Edition")
                {
                    price = 39.99;
                    if (balance - price >= 0)
                    {
                        balance -= price;
                        totalSpend += price;
                        Console.WriteLine($"Bought {comand}");
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    Environment.Exit(0);
                }
                comand = Console.ReadLine();
            }
            if (comand == "Game Time")
            {
                Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${budget - totalSpend:f2}");
            }
        }
    }
}
