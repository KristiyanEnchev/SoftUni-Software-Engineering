using System;
class House
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int stars;
        if (n % 2 == 0)
        {
            stars = 2;
        }
        else
        {
            stars = 1;
        }
        int lines = (n - stars) / 2;
        Console.Write(new string('-', lines));
        Console.Write(new string('*', stars));
        Console.WriteLine(new string('-', lines));
        for (int i = 1; i < (n + 1) / 2; i++)
        {
            stars = stars + 2;
            lines = lines - 1;
            Console.Write(new string('-', lines));
            Console.Write(new string('*', stars));
            Console.WriteLine(new string('-', lines));

        }
        for (int i = 0; i <= n / 2 - 1; i++)
        {
            Console.Write("|");
            Console.Write(new string('*', n - 2));
            Console.Write("|");
            Console.WriteLine();
        }
    }
}