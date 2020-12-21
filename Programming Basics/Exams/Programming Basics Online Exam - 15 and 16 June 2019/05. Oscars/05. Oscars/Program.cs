using System;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            string starName = Console.ReadLine();
            double academypoints = double.Parse(Console.ReadLine());
            int juryCount = int.Parse(Console.ReadLine());
            double total = academypoints;
            for (int i = 1; i <= juryCount; i++)
            {
                string juryName = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());
                total += juryName.Length * juryPoints / 2;
                if (total >= 1250.5)
                {
                    break;
                }
            }
            if (total >= 1250.5)
            {
                Console.WriteLine($"Congratulations, {starName} got a nominee for leading role with {total:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {starName} you need {1250.5 - total:f1} more!");
            }
        }
    }
}
