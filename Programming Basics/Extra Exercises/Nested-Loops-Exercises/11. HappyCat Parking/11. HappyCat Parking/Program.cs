using System;
class Program
{
    static void Main(string[] args)
    {
        int dayCount = int.Parse(Console.ReadLine());
        int hourForDay = int.Parse(Console.ReadLine());
        double total = 0;
        for (int i = 1; i <= dayCount; i++)
        {
            double dayMoneyCount = 0;
            for (int k = 1; k <= hourForDay; k++)
            {
                if (i % 2 == 0 && k % 2 != 0)
                {
                    total += 2.50;
                    dayMoneyCount += 2.50;
                }
                else if (i % 2 != 0 && k % 2 == 0)
                {
                    total += 1.25;
                    dayMoneyCount += 1.25;
                }
                else
                {
                    total += 1.00;
                    dayMoneyCount += 1.00;
                }
            }
            Console.WriteLine($"Day: {i} - {dayMoneyCount:f2} leva");
        }
        Console.WriteLine($"Total: {total:f2} leva");
    }
}