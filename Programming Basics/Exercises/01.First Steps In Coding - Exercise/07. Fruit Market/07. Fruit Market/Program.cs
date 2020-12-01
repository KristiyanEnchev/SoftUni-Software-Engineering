using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananKg = double.Parse(Console.ReadLine());
            double orangeKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double strawberryKG = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice - (raspberryPrice * 0.40);
            double bananaPrice = raspberryPrice - (raspberryPrice * 0.80);

            double money = (strawberryPrice * strawberryKG) + (bananaPrice * bananKg) + (orangePrice * orangeKg) + (raspberryPrice * raspberryKg);

            Console.WriteLine($"{money:f2}");

        }
    }
}
