using System;

namespace _04.TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            bool sTop = false;
            double productsPrice = 0;
            int count = 0;
            while (productsPrice <= buget)
            {
                string nameOfPrroduct = Console.ReadLine();
                if (nameOfPrroduct == "Stop")
                {
                    sTop = true;
                    break;
                }
                count++;
                double priceOfProduct = double.Parse(Console.ReadLine());
                if (count % 3 == 0)
                {
                    priceOfProduct /= 2;
                }
                productsPrice += priceOfProduct;
            }
            if (sTop)
            {
                Console.WriteLine($"You bought {count} products for {productsPrice:f2} leva.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money!");
                Console.WriteLine($"You need {productsPrice - buget:f2} leva!");
            }
        }
    }
}
