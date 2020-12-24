using System;

class Program
{
    static void Main(string[] args)
    {
        int easterBreadCount = int.Parse(Console.ReadLine());
        double totalSugar = 0;
        double totalFlouer = 0;
        int sugar = 0;
        int flouer = 0;
        for (int i = 0; i < easterBreadCount; i++)
        {
            int sugarCount = int.Parse(Console.ReadLine());
            int flouerCount = int.Parse(Console.ReadLine());
            totalSugar += sugarCount;
            totalFlouer += flouerCount;
            if (sugarCount >= sugar)
            {
                sugar = sugarCount;
            }
            if (flouerCount >= flouer)
            {
                flouer = flouerCount;
            }
        }
        double sugarPacks = Math.Ceiling(totalSugar / 950);
        double flouerPacks = Math.Ceiling(totalFlouer / 750);

        Console.WriteLine($"Sugar: {sugarPacks}");
        Console.WriteLine($"Flour: {flouerPacks}");
        Console.WriteLine($"Max used flour is {flouer} grams, max used sugar is {sugar} grams.");

    }
}