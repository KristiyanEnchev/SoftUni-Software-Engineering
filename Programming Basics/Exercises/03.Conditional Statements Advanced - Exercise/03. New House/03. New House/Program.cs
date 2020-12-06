using System;
using System.Globalization;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string flower = Console.ReadLine();
        double fCount = double.Parse(Console.ReadLine());
        double budjet = double.Parse(Console.ReadLine());
        double total = 0;
        double roses = 5;
        double dahlias = 3.80;
        double tulips = 2.80;
        double narcissus = 3;
        double gladiolus = 2.50;
        switch (flower)
        {
            case "Roses":
                total = fCount * roses;
                if (fCount > 80)
                {
                    total = (fCount * roses) * 0.90;
                }
                break;
            case "Dahlias":
                total = fCount * dahlias;
                if (fCount > 90)
                {
                    total = (fCount * dahlias) * 0.85;
                }
                break;
            case "Tulips":
                total = fCount * tulips;
                if (fCount > 80)
                {
                    total = (fCount * tulips) * 0.85;
                }
                break;
            case "Narcissus":
                total = fCount * narcissus;
                if (fCount < 120)
                {
                    total = fCount * narcissus * 0.15 + fCount * narcissus;
                }
                break;
            case "Gladiolus":
                total = fCount * gladiolus;
                if (fCount < 80)
                {
                    total = fCount * gladiolus * 0.20 + fCount * gladiolus;
                }
                break;
        }
        if (budjet >= total)
        {
            Console.WriteLine($"Hey, you have a great garden with {fCount} {flower} and {budjet - total:f2} leva left.");
        }
        else
        {
            Console.WriteLine($"Not enough money, you need {total - budjet:f2} leva more.");
        }
    }
}
