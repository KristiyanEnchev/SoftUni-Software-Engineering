using System;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            double minuts = double.Parse(Console.ReadLine());
            double seconds = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double secFor100Metters = double.Parse(Console.ReadLine());
            double min = minuts * 60;
            double kwotTime = min + seconds;
            double resistance = lenght / 120;
            double resistedTime = resistance * 2.5;
            double personTime = lenght / 100 * secFor100Metters;
            double total = personTime - resistedTime;
            if (total <= kwotTime)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {total:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {total - kwotTime:f3} second slower.");
            }
        }
    }
}
