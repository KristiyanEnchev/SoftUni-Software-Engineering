using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double tarte = rent * 0.20;
            double bevariges = tarte - (tarte * 0.45);
            double animator = rent / 3;

            double budget = tarte + bevariges + animator + rent;

            Console.WriteLine(budget);


        }
    }
}
