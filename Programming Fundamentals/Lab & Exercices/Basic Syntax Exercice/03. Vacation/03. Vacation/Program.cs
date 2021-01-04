using System;

class program
{
    static void Main()
    {
        int people = int.Parse(Console.ReadLine());
        string groupTipe = Console.ReadLine();
        string day = Console.ReadLine();
        double price = 0;
        if (day == "Friday")
        {
            switch (groupTipe)
            {
                case "Students":
                    price = 8.45;
                    break;
                case "Business":
                    price = 10.90;
                    break;
                case "Regular":
                    price = 15.00;
                    break;
            }
        }
        else if (day == "Saturday")
        {
            switch (groupTipe)
            {
                case "Students":
                    price = 9.80;
                    break;
                case "Business":
                    price = 15.60;
                    break;
                case "Regular":
                    price = 20.00;
                    break;
            }
        }
        else if (day == "Sunday")
        {
            switch (groupTipe)
            {
                case "Students":
                    price = 10.46;
                    break;
                case "Business":
                    price = 16.00;
                    break;
                case "Regular":
                    price = 22.50;
                    break;
            }
        }
        double total = people * price;
        if (groupTipe == "Students" && people >= 30)
        {
            total *= 0.85;
        }
        if (groupTipe == "Business" && people >= 100)
        {
            total = total / people;
            total = (people - 10) * price;
        }
        if (groupTipe == "Regular" && people >= 10 && people <= 20)
        {
            total *= 0.95;
        }
        Console.WriteLine($"Total price: {total:f2}");
    }
}
