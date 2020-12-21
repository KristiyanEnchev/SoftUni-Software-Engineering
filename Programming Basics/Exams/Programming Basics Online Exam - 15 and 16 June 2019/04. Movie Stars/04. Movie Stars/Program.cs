using System;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            bool action = false;
            while (budget >= 0)
            {
                string name = Console.ReadLine();
                if (name == "ACTION")
                {
                    action = true;
                    break;
                }
                if (name.Length <= 15)
                {
                    double money = double.Parse(Console.ReadLine());
                    budget -= money;
                }
                else
                {
                    budget -= budget * 0.20;
                }
            }
            if (action)
            {
                Console.WriteLine($"We are left with {budget:f2} leva.");
            }
            else if (budget <= 0)
            {
                Console.WriteLine($"We need {Math.Abs(budget):F2} leva for our actors.");
            }
        }
    }
}
