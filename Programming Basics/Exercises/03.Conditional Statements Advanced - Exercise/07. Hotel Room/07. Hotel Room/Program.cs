using System;
class Program
{
    static void Main(string[] args)
    {
        string mounth = Console.ReadLine();
        double nightCount = double.Parse(Console.ReadLine());
        double priceStudio = 0;
        double priceApartment = 0;

        if (mounth == "May" || mounth == "October")
        {
            priceStudio = 50.00;
            priceApartment = 65.00;
            if (nightCount > 7 && nightCount < 14)
            {
                priceStudio *= 0.95;
            }
            else if (nightCount > 14)
            {
                priceStudio *= 0.70;
                priceApartment *= 0.90;
            }
        }
        else if (mounth == "June" || mounth == "September")
        {
            priceStudio = 75.20;
            priceApartment = 68.70;
            if (nightCount > 14)
            {
                priceStudio *= 0.80;
                priceApartment *= 0.90;
            }
        }
        else if (mounth == "July" || mounth == "August")
        {
            priceStudio = 76.00;
            priceApartment = 77.00;
            if (nightCount > 14)
            {
                priceApartment *= 0.90;
            }
        }
        Console.WriteLine($"Apartment: {priceApartment * nightCount:f2} lv.");
        Console.WriteLine($"Studio: {priceStudio * nightCount:f2} lv.");
    }
}
