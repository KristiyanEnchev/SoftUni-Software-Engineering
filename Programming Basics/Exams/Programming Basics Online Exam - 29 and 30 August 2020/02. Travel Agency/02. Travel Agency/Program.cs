using System;

namespace ConsoleApp52
{
    class Program
    {
        static void Main(string[] args)
        {
            int ticketCount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            double totalPrice = ticketPrice * ticketCount;
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You can sell your client {ticketCount} tickets for the price of {ticketPrice * ticketCount}$!");
                Console.WriteLine($"Your client should become a change of {budget - totalPrice}$!");
            }
            else
            {
                Console.WriteLine($"The budget of {budget}$ is not enough. Your client can't buy {ticketCount} tickets with this budget!");
            }
        }
    }
}
