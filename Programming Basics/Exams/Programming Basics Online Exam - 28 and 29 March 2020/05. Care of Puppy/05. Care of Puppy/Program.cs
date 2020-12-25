using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInKilos = int.Parse(Console.ReadLine());
            int foodInGrams = foodInKilos * 1000;
            int totalFoodEaten = 0;
            string comand = Console.ReadLine();
            while (comand != "Adopted")
            {
                int foodEaten = int.Parse(comand);
                totalFoodEaten += foodEaten;
                comand = Console.ReadLine();
            }
            if (foodInGrams >= totalFoodEaten)
            {
                Console.WriteLine($"Food is enough! Leftovers: {foodInGrams - totalFoodEaten} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalFoodEaten - foodInGrams} grams more.");
            }
        }
    }
}