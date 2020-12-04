using System;
using System.Xml.Linq;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            string gasType = Console.ReadLine();
            double gasCount = double.Parse(Console.ReadLine());
            if (gasType == "Diesel" || gasType == "Gasoline" || gasType == "Gas")
            {
                if (gasCount >= 25)
                {
                    Console.WriteLine($"You have enough {gasType.ToLower()}.");
                }
                else if (gasCount < 25)
                {
                    Console.WriteLine($"Fill your tank with {gasType.ToLower()}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
