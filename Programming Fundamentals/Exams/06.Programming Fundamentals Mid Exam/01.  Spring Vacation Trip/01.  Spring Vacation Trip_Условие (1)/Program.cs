using System;

namespace ConsoleApp67
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTheTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            double fuelPricePerKilometer = double.Parse(Console.ReadLine());
            double foodPerpersonPerDay = double.Parse(Console.ReadLine());
            double hotelRoomPricePerNightPerPerson = double.Parse(Console.ReadLine());

            double totalHotelExpens = hotelRoomPricePerNightPerPerson * peopleCount * daysOfTheTrip;
            if (peopleCount > 10)
            {
                totalHotelExpens *= 0.75;
            }
            double totalFoodExpence = foodPerpersonPerDay * peopleCount * daysOfTheTrip;
            double currentExpence = totalFoodExpence + totalHotelExpens;
            bool isNotEnought = false;
            if (daysOfTheTrip <= 0)
            {
                isNotEnought = false;
            }
            for (int i = 1; i <= daysOfTheTrip; i++)
            {
                double kilometersADay = double.Parse(Console.ReadLine());
                currentExpence += kilometersADay * fuelPricePerKilometer;
                if (currentExpence > budget)
                {
                    isNotEnought = true;
                    break;
                }
                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpence += currentExpence * 0.40;
                    if (currentExpence >= budget)
                    {
                        isNotEnought = true;
                        break;
                    }
                }
                if (i % 7 == 0)
                {
                    double aditional = currentExpence / peopleCount;
                    currentExpence -= aditional;
                }
            }
            if (isNotEnought)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currentExpence - budget:f2}$ more.");
            }
            else
            {
                Console.WriteLine($"You have reached the destination. You have {budget - currentExpence:f2}$ budget left.");
            }
        }
    }
}
