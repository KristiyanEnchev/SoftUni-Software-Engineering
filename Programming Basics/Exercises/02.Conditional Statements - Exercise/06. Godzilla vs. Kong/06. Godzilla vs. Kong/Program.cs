using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int person = int.Parse(Console.ReadLine());
            double cloth = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;
            double clothCost = person * cloth;

            if (person > 150)
            {
                clothCost *= 0.90;
            }

            double cost = decor + clothCost;

            if (budget >= cost)
            {
                double extra = budget - cost;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {extra:f2} leva left.");
            }
            else
            {
                double need = cost - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {need:f2} leva more.");
            }
        }
    }
}
