using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());
            double procentageTaken = double.Parse(Console.ReadLine());

            double area = width * lenght * hight;
            double procent = procentageTaken * 0.01;
            double totalArea = area - (area * procent);
            double total = totalArea * 0.001;


            Console.WriteLine(total);


        }
    }
}
