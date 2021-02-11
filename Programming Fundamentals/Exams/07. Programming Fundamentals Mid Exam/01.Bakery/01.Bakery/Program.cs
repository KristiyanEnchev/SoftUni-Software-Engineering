using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerPerson = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int competition = int.Parse(Console.ReadLine());

            int totalBiscuitsAday = biscuitsPerPerson * workers;
            double totalEveryThurdDay = Math.Floor(totalBiscuitsAday * 0.75);

            double total = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    total += totalEveryThurdDay;
                }
                else
                {
                    total += totalBiscuitsAday;
                }
            }

            Console.WriteLine($"You have produced {total} biscuits for the past month.");
            if (total > competition)
            {
                double more = total - competition;
                double percentage = (more / competition) * 100;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                double more = competition - total;
                double percentage = (more / competition) * 100;
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
