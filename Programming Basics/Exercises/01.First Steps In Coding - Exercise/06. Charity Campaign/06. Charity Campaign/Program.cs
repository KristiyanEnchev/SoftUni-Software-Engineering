using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double days = double.Parse(Console.ReadLine());
            double chefs = double.Parse(Console.ReadLine());
            double tarts = double.Parse(Console.ReadLine());
            double waffles = double.Parse(Console.ReadLine());
            double pancaks = double.Parse(Console.ReadLine());

            double totalMoneyDay = (tarts * 45) + (waffles * 5.80) + (pancaks * 3.20);
            double total = (totalMoneyDay * chefs) * days;
            double totalD = total - (total / 8);

            Console.WriteLine(totalD);
        }
    }
}
