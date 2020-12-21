using System;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            string movieTime = Console.ReadLine();
            double totalIncome = 0;
            while (movieTime != "Movie time!")
            {
                int people = int.Parse(movieTime);
                if (people < 1 && people > 15)
                {
                    movieTime = Console.ReadLine();
                }
                capacity -= people;
                if (capacity < 0)
                {
                    break;
                }
                double income = people * 5.00;
                if (people % 3 == 0)
                {
                    income -= 5.00;
                }
                totalIncome += income;
                movieTime = Console.ReadLine();
            }
            if (movieTime == "Movie time!")
            {
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
            }
            else if (capacity <= 0)
            {
                if (capacity == 0)
                {
                    Console.WriteLine($"There are {capacity} seats left in the cinema.");
                }
                else
                {
                    Console.WriteLine($"The cinema is full.");
                }
            }
            Console.WriteLine($"Cinema income - {totalIncome} lv.");
        }
    }
}
