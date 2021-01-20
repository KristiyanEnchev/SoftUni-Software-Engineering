using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Purchases(product, quantity);
        }

        private static void Purchases(string type, int count)
        {
            double price = 0;
            switch (type)
            {
                case "coffee":
                    price = count * 1.50;
                    break;
                case "water":
                    price = count * 1.00;
                    break;
                case "coke":
                    price = count * 1.40;
                    break;
                case "snacks":
                    price = count * 2.00;
                    break;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
