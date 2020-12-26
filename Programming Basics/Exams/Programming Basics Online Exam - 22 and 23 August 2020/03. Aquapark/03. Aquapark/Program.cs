using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0;
            if (mounth == "march" || mounth == "april" || mounth == "may")
            {
                if (timeOfDay == "day")
                {
                    price = 10.50;
                }
                else if (timeOfDay == "night")
                {
                    price = 8.40;
                }
            }
            else if (mounth == "june" || mounth == "july" || mounth == "august")
            {
                if (timeOfDay == "day")
                {
                    price = 12.60;
                }
                else if (timeOfDay == "night")
                {
                    price = 10.20;
                }
            }
            if (people >= 4)
            {
                price *= 0.90;
            }
            if (hours >= 5)
            {
                price *= 0.50;
            }
            Console.WriteLine($"Price per person for one hour: {price:f2}");
            Console.WriteLine($"Total cost of the visit: {(price * people) * hours:f2}");
        }
    }
}
