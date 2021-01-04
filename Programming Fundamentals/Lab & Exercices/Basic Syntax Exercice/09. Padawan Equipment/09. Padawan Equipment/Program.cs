using System;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentCount = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double extraLightsabers = Math.Ceiling(studentCount * 1.10);
            int freeBelt = studentCount / 6;

            double totalLightsaber = extraLightsabers * lightSaberPrice;
            double totalbelts = (studentCount - freeBelt) * beltPrice;
            double totalrobe = robePrice * studentCount;
            double total = totalLightsaber + totalbelts + totalrobe;
            if (budget >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {total - budget:f2}lv more.");
            }
        }
    }
}
