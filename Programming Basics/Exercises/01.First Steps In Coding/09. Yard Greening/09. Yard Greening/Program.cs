using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());

            double total = area * 7.61;
            double discountPrice = total * 0.82;
            double discount = total - discountPrice;

            Console.WriteLine($"The final price is: {discountPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");


        }
    }
}
