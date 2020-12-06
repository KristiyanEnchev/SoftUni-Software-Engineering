using System;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double line = double.Parse(Console.ReadLine());
            double colum = double.Parse(Console.ReadLine());
            double price = 0;
            if (type == "Premiere")
            {
                price = 12.00;
            }
            else if (type == "Normal")
            {
                price = 7.50;
            }
            else if (type == "Discount")
            {
                price = 5.00;
            }
            double income = (line * colum) * price;
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
