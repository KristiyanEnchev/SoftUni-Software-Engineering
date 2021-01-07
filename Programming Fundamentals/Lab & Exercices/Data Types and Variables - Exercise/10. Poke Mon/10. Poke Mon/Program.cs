using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int Y = int.Parse(Console.ReadLine());

        int pokedCount = 0;
        decimal halfValue = N * 0.50m;

        while (N >= M)
        {
            if (N == halfValue)
            {
                if (Y > 0)
                {
                    N = N / Y;
                    if (N < M)
                    {
                        break;
                    }
                }
            }
            N -= M;
            pokedCount++;
        }
        Console.WriteLine(N);
        Console.WriteLine(pokedCount);
    }
}
