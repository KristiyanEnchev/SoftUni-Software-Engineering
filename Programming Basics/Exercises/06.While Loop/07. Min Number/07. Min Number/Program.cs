using System;

class Program
{
    static void Main(string[] args)
    {
        string comand = Console.ReadLine();
        int min = int.MaxValue;
        while (comand != "Stop")
        {
            int num = int.Parse(comand);
            if (num < min)
            {
                min = num;
            }
            comand = Console.ReadLine();
        }
        Console.WriteLine(min);
    }
}
