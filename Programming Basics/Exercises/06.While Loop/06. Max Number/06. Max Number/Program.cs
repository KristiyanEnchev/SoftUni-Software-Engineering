using System;

class Program
{
    static void Main(string[] args)
    {
        string comand = Console.ReadLine();
        int max = int.MinValue;
        while (comand != "Stop")
        {
            int num = int.Parse(comand);
            if (num > max)
            {
                max = num;
            }
            comand = Console.ReadLine();
        }
        Console.WriteLine(max);
    }
}
