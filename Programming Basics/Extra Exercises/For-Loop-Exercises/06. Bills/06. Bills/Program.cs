using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalMounts = int.Parse(Console.ReadLine());
            double totalEl = 0;
            double totalExtra = 0;
            for (int i = 1; i <= totalMounts; i++)
            {
                double electricyty = double.Parse(Console.ReadLine());
                double extra = (electricyty + 20 + 15) * 1.20;
                totalEl += electricyty;
                totalExtra += extra;
            }
            double totalWater = totalMounts * 20;
            double totalInternet = totalMounts * 15;
            double avarage = (totalWater + totalInternet + totalEl + totalExtra) / totalMounts;
            Console.WriteLine($"Electricity: {totalEl:f2} lv");
            Console.WriteLine($"Water: {totalWater:f2} lv");
            Console.WriteLine($"Internet: {totalInternet:f2} lv");
            Console.WriteLine($"Other: {totalExtra:f2} lv");
            Console.WriteLine($"Average: {avarage:f2} lv");
        }
    }
}
