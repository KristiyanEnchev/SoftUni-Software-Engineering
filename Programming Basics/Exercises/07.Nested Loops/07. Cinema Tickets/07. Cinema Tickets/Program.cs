using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        int totalTikets = 0;
        int student = 0;
        int kid = 0;
        int standard = 0;
        while (true)
        {
            string movie = Console.ReadLine();
            if (movie == "Finish")
            {
                break;
            }
            int capacity = int.Parse(Console.ReadLine());
            int movieTickets = 0;
            while (true)
            {
                string type = Console.ReadLine();
                if (type == "End")
                {
                    break;
                }
                switch (type)
                {
                    case "student":
                        student++;
                        break;
                    case "standard":
                        standard++;
                        break;
                    case "kid":
                        kid++;
                        break;
                }
                movieTickets++;
                if (movieTickets >= capacity)
                {
                    break;
                }
            }
            Console.WriteLine($"{movie} - {100.0 * movieTickets / capacity:f2}% full.");
            totalTikets += movieTickets;
        }
        Console.WriteLine($"Total tickets: {totalTikets}");
        Console.WriteLine($"{100.0 * student / totalTikets:f2}% student tickets.");
        Console.WriteLine($"{100.0 * standard / totalTikets:f2}% standard tickets.");
        Console.WriteLine($"{100.0 * kid / totalTikets:f2}% kids tickets.");
    }
}
