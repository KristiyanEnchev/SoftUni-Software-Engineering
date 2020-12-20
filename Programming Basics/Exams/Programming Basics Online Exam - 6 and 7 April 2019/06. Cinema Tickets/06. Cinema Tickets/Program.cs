using System;

namespace ConsoleApp41
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalTickets = 0;
            double standard = 0;
            double student = 0;
            double kid = 0;
            while (true)
            {
                string movieName = Console.ReadLine();
                double sitTaken = 0;
                if (movieName == "Finish")
                {
                    break;
                }
                int freeSits = int.Parse(Console.ReadLine());
                for (int i = 1; i <= freeSits; i++)
                {
                    string type = Console.ReadLine();
                    if (type == "End")
                    {
                        break;
                    }
                    sitTaken++;
                    if (type == "student")
                    {
                        student++;
                        totalTickets++;
                    }
                    else if (type == "standard")
                    {
                        standard++;
                        totalTickets++;
                    }
                    else if (type == "kid")
                    {
                        kid++;
                        totalTickets++;
                    }
                }
                Console.WriteLine($"{movieName} - {sitTaken / freeSits * 100:f2}% full.");
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{student / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standard / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kid / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
