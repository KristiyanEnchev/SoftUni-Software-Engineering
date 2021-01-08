using System;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] daysOfTheWeek =
            {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

            if (num < 1 || num > daysOfTheWeek.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysOfTheWeek[num - 1]);
            }
        }
    }
}
