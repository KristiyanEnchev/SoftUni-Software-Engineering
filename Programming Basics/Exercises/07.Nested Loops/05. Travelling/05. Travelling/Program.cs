using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string destination = Console.ReadLine();
            if (destination == "End")
            {
                break;
            }
            double budjet = double.Parse(Console.ReadLine());
            while (budjet > 0)
            {
                double sum = double.Parse(Console.ReadLine());
                budjet -= sum;
            }
            Console.WriteLine($"Going to {destination}!");
        }
    }
}
