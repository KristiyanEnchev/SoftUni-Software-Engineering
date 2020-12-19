using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double wantedIncome = double.Parse(Console.ReadLine());
            double income = 0;
            bool party = false;
            bool targetReached = false;
            while (true)
            {
                string coctailName = Console.ReadLine();
                if (coctailName == "Party!")
                {
                    party = true;
                    break;
                }
                int coctailCount = int.Parse(Console.ReadLine());
                int price = coctailName.Length;
                double totalOrder = coctailCount * price;
                if (totalOrder % 2 != 0)
                {
                    totalOrder *= 0.75;
                }
                income += totalOrder;
                if (income >= wantedIncome)
                {
                    targetReached = true;
                    break;
                }
            }
            if (party)
            {
                Console.WriteLine($"We need {wantedIncome - income:f2} leva more.");
            }
            else if (targetReached)
            {
                Console.WriteLine("Target acquired.");
            }
            Console.WriteLine($"Club income - {income:f2} leva.");
        }
    }
}
