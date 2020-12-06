using System;

class Program
{
    static void Main(string[] args)
    {
        double budjet = double.Parse(Console.ReadLine());
        string season = Console.ReadLine();
        string location = "";
        double moneySpend = 0;
        string destination = "";
        if (budjet <= 100)
        {
            destination = "Bulgaria";
            if (season == "summer")
            {
                location = "Camp";
                moneySpend = budjet * 0.30;
            }
            else if (season == "winter")
            {
                location = "Hotel";
                moneySpend = budjet * 0.70;
            }
        }
        else if (budjet <= 1000)
        {
            destination = "Balkans";
            if (season == "summer")
            {
                location = "Camp";
                moneySpend = budjet * 0.40;
            }
            else if (season == "winter")
            {
                location = "Hotel";
                moneySpend = budjet * 0.80;
            }
        }
        else if (budjet > 1000)
        {
            destination = "Europe";
            location = "Hotel";
            moneySpend = budjet * 0.90;
        }
        Console.WriteLine($"Somewhere in {destination}");
        Console.WriteLine($"{location} - {moneySpend:f2}");
    }
}
