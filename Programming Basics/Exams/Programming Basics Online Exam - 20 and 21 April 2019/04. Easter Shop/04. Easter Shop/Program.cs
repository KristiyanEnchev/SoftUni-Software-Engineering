using System;
class Program
{
    static void Main(string[] args)
    {
        double eggCount = double.Parse(Console.ReadLine());
        string comand = Console.ReadLine();
        double egsSold = 0;
        double eggsFill = 0;
        double curentEggs = eggCount;
        while (comand != "Close")
        {
            int eggs = int.Parse(Console.ReadLine());
            if (comand == "Buy")
            {
                curentEggs -= eggs;
                if (curentEggs < 0)
                {
                    break;
                }
                egsSold += eggs;
            }
            else if (comand == "Fill")
            {
                curentEggs += eggs;
                eggsFill += eggs;
            }
            comand = Console.ReadLine();
        }
        if (comand == "Close")
        {
            Console.WriteLine($"Store is closed!");
            Console.WriteLine($"{egsSold} eggs sold.");
        }
        else
        {
            Console.WriteLine($"Not enough eggs in store!");
            Console.WriteLine($"You can buy only {(eggCount + eggsFill) - egsSold}.");
        }
    }
}