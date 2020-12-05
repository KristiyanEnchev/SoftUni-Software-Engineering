using System;
class Program
{
    static void Main(string[] args)
    {
        double dayCount = double.Parse(Console.ReadLine());
        string place = Console.ReadLine();
        string grade = Console.ReadLine();
        double nights = dayCount - 1;
        double total = 0;

        if (dayCount < 10)
        {
            if (place == "room for one person")
            {
                total = nights * 18.00;
            }
            else if (place == "apartment")
            {
                total = (nights * 25.00) * 0.70;
            }
            else if (place == "president apartment")
            {
                total = (nights * 35.00) * 0.90;
            }
        }
        else if (dayCount >= 10 && dayCount <= 15)
        {
            if (place == "room for one person")
            {
                total = nights * 18.00;
            }
            else if (place == "apartment")
            {
                total = (nights * 25.00) * 0.65;
            }
            else if (place == "president apartment")
            {
                total = (nights * 35.00) * 0.85;
            }
        }
        else if (dayCount > 15)
        {
            if (place == "room for one person")
            {
                total = nights * 18.00;
            }
            else if (place == "apartment")
            {
                total = (nights * 25.00) * 0.50;
            }
            else if (place == "president apartment")
            {
                total = (nights * 35.00) * 0.80;
            }
        }
        if (grade == "positive")
        {
            Console.WriteLine($"{total + (total * 0.25):f2}");
        }
        else if (grade == "negative")
        {
            Console.WriteLine($"{total - (total * 0.10):f2}");
        }
    }
}
