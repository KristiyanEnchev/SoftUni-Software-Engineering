using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double cordinateXone = double.Parse(Console.ReadLine());
            double cordinateYone = double.Parse(Console.ReadLine());
            double cordinateXtwo = double.Parse(Console.ReadLine());
            double cordinateYtwo = double.Parse(Console.ReadLine());

            double lineCordinateXone = double.Parse(Console.ReadLine());
            double lineCordinateYone = double.Parse(Console.ReadLine());
            double lineCordinateXtwo = double.Parse(Console.ReadLine());
            double lineCordinateYtwo = double.Parse(Console.ReadLine());

            double firstCordinate = ClosestToZetoOfSecondPair(cordinateXone, cordinateYone, cordinateXtwo, cordinateYtwo);
            double secondCordinate = ClosestToZetoOfSecondPair(lineCordinateXone, lineCordinateYone, lineCordinateXtwo, lineCordinateYtwo);

            if (firstCordinate > secondCordinate)
            {
                FindingClosestToStartingPoint(cordinateXone, cordinateYone, cordinateXtwo, cordinateYtwo);
            }
            else if (firstCordinate == secondCordinate)
            {
                FindingClosestToStartingPoint(cordinateXone, cordinateYone, cordinateXtwo, cordinateYtwo);
            }
            else
            {
                FindingClosestToStartingPoint(lineCordinateXone, lineCordinateYone, lineCordinateXtwo, lineCordinateYtwo);
            }
        }

        public static void FindingClosestToStartingPoint(double cordinateXone, double cordinateYone, double cordinateXtwo, double cordinateYtwo)
        {
            double firstCordinate = ClosestToStartingCordinate(cordinateXone, cordinateYone);
            double secondCordinate = ClosestToStartingCordinate(cordinateXtwo, cordinateYtwo);

            if (firstCordinate < secondCordinate)
            {
                Console.WriteLine($"({cordinateXone}, {cordinateYone})({cordinateXtwo}, {cordinateYtwo})");
            }
            else if (firstCordinate == secondCordinate)
            {
                Console.WriteLine($"({cordinateXone}, {cordinateYone})({cordinateXtwo}, {cordinateYtwo})");
            }
            else
            {
                Console.WriteLine($"({cordinateXtwo}, {cordinateYtwo})({cordinateXone}, {cordinateYone})");
            }
        }

        public static double ClosestToZetoOfSecondPair(double cordinateXone, double cordinateYone, double cordinateXtwo, double cordinateYtwo)
        {
            double firstCordinate = ClosestToStartingCordinate(cordinateXone, cordinateYone);
            double secondCordinate = ClosestToStartingCordinate(cordinateXtwo, cordinateYtwo);

            double sum = firstCordinate + secondCordinate;

            return sum;
        }

        public static double ClosestToStartingCordinate(double oneX, double oneY)
        {
            double result = Math.Sqrt(Math.Pow(oneX, 2) + Math.Pow(oneY, 2));

            return result;
        }
    }
}
