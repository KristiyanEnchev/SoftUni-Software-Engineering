using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double pagesInBook = double.Parse(Console.ReadLine());
            double pageFor1h = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            double pagesForDay = pagesInBook / days;
            double hoursADay = pagesForDay / pageFor1h;

            Console.WriteLine(hoursADay);

        }
    }
}
