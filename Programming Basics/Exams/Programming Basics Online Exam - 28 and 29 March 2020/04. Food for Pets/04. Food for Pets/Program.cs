using System;
using System.Text;
using System.Transactions;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            int daycount = int.Parse(Console.ReadLine());
            double totalFoodinGrams = double.Parse(Console.ReadLine());
            double biscuitCount = 0;
            double dogFoodForTheday = 0;
            double CatFoodForTheDay = 0;
            double totalDogFood = 0;
            double totalCatFood = 0;
            for (int i = 1; i <= daycount; i++)
            {
                if (totalCatFood + totalDogFood >= totalFoodinGrams)
                {
                    break;
                }
                dogFoodForTheday = 0;
                CatFoodForTheDay = 0;
                double foodEatenByDog = double.Parse(Console.ReadLine());
                double foodEatenByCat = double.Parse(Console.ReadLine());
                totalCatFood += foodEatenByCat;
                totalDogFood += foodEatenByDog;
                dogFoodForTheday += foodEatenByDog;
                CatFoodForTheDay += foodEatenByCat;
                if (i % 3 == 0)
                {
                    double currentBiscuit = (dogFoodForTheday + CatFoodForTheDay) * 0.10;
                    biscuitCount += currentBiscuit;
                }
            }
            double totalfoodEaten = totalDogFood + totalCatFood;
            double totalProcent = totalfoodEaten / totalFoodinGrams / 0.01;
            double procentDog = totalDogFood / totalfoodEaten / 0.01;
            double procentCat = totalCatFood / totalfoodEaten / 0.01;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitCount)}gr.");
            Console.WriteLine($"{totalProcent:f2}% of the food has been eaten.");
            Console.WriteLine($"{procentDog:f2}% eaten from the dog.");
            Console.WriteLine($"{procentCat:f2}% eaten from the cat.");
        }
    }
}
