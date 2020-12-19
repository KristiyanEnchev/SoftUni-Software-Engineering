using System;

namespace ConsoleApp40
{
    class Program
    {
        static void Main(string[] args)
        {
            double hight = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double procent = double.Parse(Console.ReadLine());
            double procentage = procent * 0.01;
            double area = hight * width * 4;
            double totalForPainting = Math.Ceiling(area - (area * procentage));
            bool tired = false;
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "Tired!")
                {
                    tired = true;
                    break;
                }
                double paintCount = double.Parse(comand);
                totalForPainting -= paintCount;
                if (totalForPainting <= 0)
                {
                    break;
                }
            }
            if (tired)
            {
                Console.WriteLine($"{totalForPainting} quadratic m left.");
            }
            else if (totalForPainting < 0)
            {
                Console.WriteLine($"All walls are painted and you have {Math.Abs(totalForPainting)} l paint left!");
            }
            else if (totalForPainting == 0)
            {
                Console.WriteLine($"All walls are painted! Great job, Pesho!");
            }
        }
    }
}
