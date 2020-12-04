using System;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            string gasType = Console.ReadLine();
            double gasCount = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();
            double price = 0;
            if (gasType == "Gas")
            {
                price = 0.93;
                if (card == "Yes")
                {
                    price -= 0.08;
                }
            }
            else if (gasType == "Gasoline")
            {
                price = 2.22;
                if (card == "Yes")
                {
                    price -= 0.18;
                }
            }
            else if (gasType == "Diesel")
            {
                price = 2.33;
                if (card == "Yes")
                {
                    price -= 0.12;
                }
            }
            if (gasCount >= 20 && gasCount <= 25)
            {
                price *= 0.92;
            }
            else if (gasCount > 25)
            {
                price *= 0.90;
            }
            Console.WriteLine($"{price * gasCount:f2} lv.");
        }
    }
}
