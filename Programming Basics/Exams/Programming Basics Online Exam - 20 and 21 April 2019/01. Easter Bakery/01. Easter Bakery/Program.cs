using System;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            double FlourPrice = double.Parse(Console.ReadLine());
            double flourCount = double.Parse(Console.ReadLine());
            double sugarCount = double.Parse(Console.ReadLine());
            double eggCount = double.Parse(Console.ReadLine());
            double mayCount = double.Parse(Console.ReadLine());

            double sugarPrice = FlourPrice * 0.75;
            double eggPrice = FlourPrice * 1.10;
            double mayPrice = sugarPrice * 0.20;

            double total = FlourPrice * flourCount + sugarPrice * sugarCount + eggPrice * eggCount + mayPrice * mayCount;

            Console.WriteLine($"{total:f2}");
        }
    }
}
