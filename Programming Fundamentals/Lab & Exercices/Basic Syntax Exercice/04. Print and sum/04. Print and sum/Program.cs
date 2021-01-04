using System;

class program
{
    static void Main()
    {
        int strat = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        int total = 0;
        for (int i = strat; i <= end; i++)
        {
            total += i;
            Console.Write($"{i} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Sum: {total}");
    }
}
