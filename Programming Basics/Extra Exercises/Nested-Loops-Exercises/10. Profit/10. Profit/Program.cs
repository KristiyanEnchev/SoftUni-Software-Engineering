using System;
class Program
{
    static void Main(string[] args)
    {
        int lev1 = int.Parse(Console.ReadLine());
        int lev2 = int.Parse(Console.ReadLine());
        int lev5 = int.Parse(Console.ReadLine());
        int money = int.Parse(Console.ReadLine());
        for (int i = 0; i <= lev1; i++)
        {
            for (int j = 0; j <= lev2; j++)
            {
                for (int k = 0; k <= lev5; k++)
                {
                    if (i * 1 + j * 2 + k * 5 == money)
                    {
                        Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {money} lv.");
                    }
                }
            }
        }
    }
}