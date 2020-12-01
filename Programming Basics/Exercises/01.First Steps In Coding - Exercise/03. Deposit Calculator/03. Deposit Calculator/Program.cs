using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            double timeFrame = double.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());

            double procentC = procent / 100;
            double total = deposit + timeFrame * ((deposit * procentC) / 12);

            Console.WriteLine(total);
        }
    }
}
