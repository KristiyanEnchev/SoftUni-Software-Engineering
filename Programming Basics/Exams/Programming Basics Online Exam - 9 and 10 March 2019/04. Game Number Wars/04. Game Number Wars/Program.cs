using System;

namespace ConsoleApp42
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();
            double firstPoints = 0;
            double secondPoints = 0;
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "End of game")
                {
                    Console.WriteLine($"{firstPlayerName} has {firstPoints} points");
                    Console.WriteLine($"{secondPlayerName} has {secondPoints} points");
                    break;
                }
                int first = int.Parse(comand);
                int second = int.Parse(Console.ReadLine());
                if (first > second)
                {
                    firstPoints += first - second;
                }
                else if (second > first)
                {
                    secondPoints += second - first;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    first = int.Parse(Console.ReadLine());
                    second = int.Parse(Console.ReadLine());
                    if (first > second)
                    {
                        Console.WriteLine($"{firstPlayerName} is winner with {firstPoints} points");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{secondPlayerName} is winner with {secondPoints} points");
                        break;
                    }
                }
            }
        }
    }
}
