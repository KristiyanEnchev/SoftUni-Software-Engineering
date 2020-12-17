using System;
class Program
{
    static void Main(string[] args)
    {
        int firstTop = int.Parse(Console.ReadLine());
        int secondTop = int.Parse(Console.ReadLine());
        int thurdTop = int.Parse(Console.ReadLine());
        for (int i = 1; i <= firstTop; i++)
        {
            for (int j = 1; j <= secondTop; j++)
            {
                for (int k = 1; k <= thurdTop; k++)
                {
                    if (i % 2 == 0 && k % 2 == 0)
                    {
                        if (j == 2 || j == 3 || j == 5 || j == 7)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}