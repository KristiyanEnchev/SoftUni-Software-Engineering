using System;

class Program
{
    static void Main(string[] args)
    {
        double capacity = double.Parse(Console.ReadLine());
        int bagCount = 0;
        int bagProcesed = 0;
        string comand = Console.ReadLine();
        while (capacity > 0)
        {
            bagProcesed++;
            double bagCapacity = double.Parse(comand);
            if (bagProcesed % 3 == 0)
            {
                bagCapacity *= 1.10;
            }
            capacity -= bagCapacity;
            if (capacity <= 0)
            {
                break;
            }
            bagCount++;
            comand = Console.ReadLine();
            if (comand == "End")
            {
                break;
            }
        }
        if (capacity <= 0)
        {
            Console.WriteLine("No more space!");
        }
        else if (comand == "End")
        {
            Console.WriteLine("Congratulations! All suitcases are loaded!");
        }
        Console.WriteLine($"Statistic: {bagCount} suitcases loaded.");
    }
}