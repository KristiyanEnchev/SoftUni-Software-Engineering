using System;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            double price = 0;
            if (age >= 0 && age <= 18)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 5;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else if (age >= 19 && age <= 64)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 18;
                        break;
                    case "Weekend":
                        price = 20;
                        break;
                    case "Holiday":
                        price = 12;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else if (age >= 65 && age <= 122)
            {
                switch (day)
                {
                    case "Weekday":
                        price = 12;
                        break;
                    case "Weekend":
                        price = 15;
                        break;
                    case "Holiday":
                        price = 10;
                        break;
                }
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
