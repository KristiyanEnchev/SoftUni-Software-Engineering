using System;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            double vaucherPrice = double.Parse(Console.ReadLine());
            int ticketsCount = 0;
            int productCount = 0;
            while (true)
            {
                if (vaucherPrice <= 0)
                {
                    break;
                }
                string stock = Console.ReadLine();
                if (stock == "End")
                {
                    break;
                }
                if (stock.Length > 8)
                {
                    double moviePrice = 0;
                    for (int i = 0; i < stock.Length; i++)
                    {
                        char letter = (char)stock[i];
                        int ascii = letter;
                        if (i < 2)
                        {
                            moviePrice += ascii;
                            if (vaucherPrice < 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    vaucherPrice -= moviePrice;
                    if (vaucherPrice >= 0)
                    {
                        ticketsCount++;
                    }
                }
                else if (stock.Length <= 8)
                {
                    for (int i = 0; i < stock.Length; i++)
                    {
                        char letter = (char)stock[i];
                        int ascii = letter;
                        if (i <= 0)
                        {
                            vaucherPrice -= ascii;
                            if (vaucherPrice < 0)
                            {
                                break;
                            }
                            else if (vaucherPrice >= 0)
                            {
                                productCount++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"{ticketsCount}");
            Console.WriteLine($"{productCount}");
        }
    }
}
