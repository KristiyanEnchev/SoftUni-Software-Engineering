using System;

class Program
{
    static void Main(string[] args)
    {
        for (int x1 = 1; x1 <= 10; x1++)
        {
            for (int x2 = 1; x2 <= 10; x2++)
            {
                int sum = x1 * x2;
                Console.WriteLine($"{x1} * {x2} = {sum}");
            }
        }
    }
}
