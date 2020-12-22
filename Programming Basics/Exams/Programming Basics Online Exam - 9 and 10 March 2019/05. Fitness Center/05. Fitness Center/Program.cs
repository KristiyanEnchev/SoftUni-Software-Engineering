using System;
using System.Net;
using System.Runtime;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            double peopleInGym = double.Parse(Console.ReadLine());
            double back = 0;
            double chest = 0;
            double legs = 0;
            double abs = 0;
            double proteinShake = 0;
            double proteinBar = 0;
            double workout = 0;
            double product = 0;
            for (int i = 1; i <= peopleInGym; i++)
            {
                string operationType = Console.ReadLine();
                switch (operationType)
                {
                    case "Back":
                        back++;
                        workout++;
                        break;
                    case "Chest":
                        chest++;
                        workout++;
                        break;
                    case "Legs":
                        legs++;
                        workout++;
                        break;
                    case "Abs":
                        abs++;
                        workout++;
                        break;
                    case "Protein shake":
                        proteinShake++;
                        product++;
                        break;
                    case "Protein bar":
                        proteinBar++;
                        product++;
                        break;
                }
            }
            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{workout / peopleInGym * 100:f2}% - work out");
            Console.WriteLine($"{product / peopleInGym * 100:f2}% - protein");
        }
    }
}
