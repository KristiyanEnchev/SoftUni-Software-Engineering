using System;

class Program
{
    static void Main(string[] args)
    {
        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double cakeSize = lenght * width;
        string comand = Console.ReadLine();
        double pieceCount = 0;
        while (comand != "STOP")
        {
            int count = int.Parse(comand);
            pieceCount += count;
            if (pieceCount > cakeSize)
            {
                Console.WriteLine($"No more cake left! You need {pieceCount - cakeSize} pieces more.");
                break;
            }
            comand = Console.ReadLine();
        }
        if (comand == "STOP")
        {
            Console.WriteLine($"{cakeSize - pieceCount} pieces are left.");
        }
    }
}
