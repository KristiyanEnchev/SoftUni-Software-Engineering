using System;
class Program
{
    static void Main(string[] args)
    {
        string movieName = Console.ReadLine();
        int days = int.Parse(Console.ReadLine());
        int ticketCount = int.Parse(Console.ReadLine());
        double ticketPrice = double.Parse(Console.ReadLine());
        double procent = double.Parse(Console.ReadLine());

        double moneyADay = ticketPrice * ticketCount;
        double totalprice = moneyADay * days;
        double moneyForCinema = (totalprice * procent) / 100;
        Console.WriteLine($"The profit from the movie {movieName} is {totalprice - moneyForCinema:f2} lv.");
    }
}