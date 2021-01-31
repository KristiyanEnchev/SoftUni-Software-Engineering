using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            double cordinateXone = double.Parse(Console.ReadLine());
            double cordinateYone = double.Parse(Console.ReadLine());
            double cordinateXtwo = double.Parse(Console.ReadLine());
            double cordinateYtwo = double.Parse(Console.ReadLine());

            FindingClosestToStartingPoint(cordinateXone, cordinateYone, cordinateXtwo, cordinateYtwo);
        }

        public static void FindingClosestToStartingPoint(double cordinateXone, double cordinateYone, double cordinateXtwo, double cordinateYtwo)
        {
            double firstCordinate = ClosestToStartingCordinate(cordinateXone, cordinateYone);
            double secondCordinate = ClosestToStartingCordinate(cordinateXtwo, cordinateYtwo);

            if (firstCordinate < secondCordinate)
            {
                Console.WriteLine($"({cordinateXone}, {cordinateYone})");
            }
            else if (firstCordinate == secondCordinate)
            {
                Console.WriteLine($"({cordinateXone}, {cordinateYone})");
            }
            else
            {
                Console.WriteLine($"({cordinateXtwo}, {cordinateYtwo})");
            }
        }

        public static double ClosestToStartingCordinate(double oneX, double oneY)
        {
            double result = Math.Sqrt(Math.Pow(oneX, 2) + Math.Pow(oneY, 2));

            return result;
        }
    }
}