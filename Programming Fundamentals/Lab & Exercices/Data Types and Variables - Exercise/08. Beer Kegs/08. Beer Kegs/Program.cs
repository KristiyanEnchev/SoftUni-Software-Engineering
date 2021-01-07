using System;

namespace ConsoleApp56
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            double bigestVolume = double.MinValue;
            string bestKeg = "";
            for (int i = 1; i <= lines; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;
                if (volume >= bigestVolume)
                {
                    bigestVolume = volume;
                    bestKeg = model;
                }
            }
            Console.WriteLine(bestKeg);
        }
    }
}
