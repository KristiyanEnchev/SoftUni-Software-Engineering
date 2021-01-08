using System;
using System.Linq;

namespace ConsoleApp63
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(arr[i])} => {Convert.ToDecimal(Math.Round(arr[i], MidpointRounding.AwayFromZero))}");
            }
        }
    }
}
