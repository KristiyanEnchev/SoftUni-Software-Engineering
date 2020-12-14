using System;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            double studentsCount = double.Parse(Console.ReadLine());
            double nightsCount = double.Parse(Console.ReadLine());
            string sport = "";
            double price = 0;
            if (season == "Winter")
            {
                if (groupType == "boys")
                {
                    sport = "Judo";
                    price = 9.60;
                }
                else if (groupType == "girls")
                {
                    sport = "Gymnastics";
                    price = 9.60;
                }
                else if (groupType == "mixed")
                {
                    sport = "Ski";
                    price = 10.00;
                }
            }
            else if (season == "Spring")
            {
                if (groupType == "boys")
                {
                    sport = "Tennis";
                    price = 7.20;
                }
                else if (groupType == "girls")
                {
                    sport = "Athletics";
                    price = 7.20;
                }
                else if (groupType == "mixed")
                {
                    sport = "Cycling";
                    price = 9.50;
                }
            }
            else if (season == "Summer")
            {
                if (groupType == "boys")
                {
                    sport = "Football";
                    price = 15.00;
                }
                else if (groupType == "girls")
                {
                    sport = "Volleyball";
                    price = 15.00;
                }
                else if (groupType == "mixed")
                {
                    sport = "Swimming";
                    price = 20.00;
                }
            }
            double total = (price * nightsCount) * studentsCount;
            if (studentsCount >= 10 && studentsCount < 20)
            {
                total *= 0.95;
            }
            else if (studentsCount >= 20 && studentsCount < 50)
            {
                total *= 0.85;
            }
            else if (studentsCount >= 50)
            {
                total *= 0.50;
            }
            Console.WriteLine($"{sport} {total:f2} lv.");
        }
    }
}
