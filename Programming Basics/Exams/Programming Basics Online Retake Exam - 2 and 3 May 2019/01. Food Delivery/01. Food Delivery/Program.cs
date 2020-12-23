using System;

namespace ConsoleApp36
{
    class Program
    {
        static void Main(string[] args)
        {
            double chikenMenuCount = double.Parse(Console.ReadLine());
            double fishMenuCount = double.Parse(Console.ReadLine());
            double vegitarianMenuCount = double.Parse(Console.ReadLine());

            double total = chikenMenuCount * 10.35 + fishMenuCount * 12.40 + vegitarianMenuCount * 8.15;
            double totalWithDesert = total * 1.20;
            double totalPrice = totalWithDesert + 2.50;
            Console.WriteLine($"Total: {totalPrice:f2}");
        }
    }
}
