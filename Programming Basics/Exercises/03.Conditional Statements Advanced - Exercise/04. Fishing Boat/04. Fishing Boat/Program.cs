using System;
class Program
{
    static void Main(string[] args)
    {
        int budget = int.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        int fishers = int.Parse(Console.ReadLine());
        double priceShip = 0;

        if (season == "Spring")
        {
            priceShip = 3000;
        }
        else if (season == "Summer" || season == "Autumn")
        {
            priceShip = 4200;
        }
        else if (season == "Winter")
        {
            priceShip = 2600;
        }
        if (fishers <= 6)
        {
            priceShip *= 0.90;
        }
        else if (fishers >= 7 && fishers <= 11)
        {
            priceShip *= 0.85;
        }
        else if (fishers >= 12)
        {
            priceShip *= 0.75;
        }
        if (fishers % 2 == 0 && season != "Autumn")
        {
            priceShip *= 0.95;
        }
        if (budget >= priceShip)
        {
            Console.WriteLine($"Yes! You have {budget - priceShip:F2} leva left.");
        }
        else
        {
            Console.WriteLine($"Not enough money! You need {priceShip - budget:f2} leva.");
        }
    }
}