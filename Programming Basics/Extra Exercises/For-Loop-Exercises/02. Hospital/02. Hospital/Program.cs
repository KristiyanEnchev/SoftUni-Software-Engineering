using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treated = 0;
            int untreated = 0;
            for (int i = 1; i <= period; i++)
            {
                if (i % 3 == 0)
                {
                    if (untreated > treated)
                    {
                        doctors++;
                    }
                }
                int paciantCount = int.Parse(Console.ReadLine());
                if (paciantCount > doctors)
                {
                    untreated += paciantCount - doctors;
                    treated += doctors;
                }
                else if (paciantCount == doctors)
                {
                    treated += doctors;
                }
                else
                {
                    treated += paciantCount;
                }
            }
            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
