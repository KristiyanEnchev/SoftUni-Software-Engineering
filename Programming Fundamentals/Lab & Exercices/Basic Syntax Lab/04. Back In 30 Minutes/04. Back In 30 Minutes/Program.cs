using System;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            int houres = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int endMin = min + 30;
            if (endMin > 59)
            {
                houres++;
                if (houres > 23)
                {
                    houres -= 24;
                }
                endMin -= 60;
            }
            Console.WriteLine($"{houres}:{endMin:d2}");
        }
    }
}
