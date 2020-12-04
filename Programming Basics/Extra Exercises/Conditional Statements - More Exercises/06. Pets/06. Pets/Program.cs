using System;
using System.Xml.Linq;

namespace ConsoleApp37
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayCount = int.Parse(Console.ReadLine());
            double foodCount = double.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turtleFood = double.Parse(Console.ReadLine());
            double turtleFoodinKilo = turtleFood / 1000;
            double totalFood = (dogFood + catFood + turtleFoodinKilo) * dayCount;
            if (foodCount >= totalFood)
            {
                Console.WriteLine($"{Math.Floor(foodCount - totalFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFood - foodCount)} more kilos of food are needed.");
            }
        }
    }
}
