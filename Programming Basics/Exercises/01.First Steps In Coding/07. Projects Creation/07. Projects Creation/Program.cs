using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());

            double h = projects * 3;

            Console.WriteLine($"The architect {name} will need {h} hours to complete {projects} project/s.");

        }
    }
}
