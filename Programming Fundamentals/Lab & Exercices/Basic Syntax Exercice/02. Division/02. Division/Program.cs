using System;

class program
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int divNum = 0;
        if (num % 2 == 0)
        {
            divNum = 2;
        }
        if (num % 3 == 0)
        {
            divNum = 3;
        }
        if (num % 6 == 0)
        {
            divNum = 6;
        }
        if (num % 7 == 0)
        {
            divNum = 7;
        }
        if (num % 10 == 0)
        {
            divNum = 10;
        }
        if (num % 2 != 0 && num % 3 != 0 && num % 6 != 0 && num % 7 != 0 && num % 10 != 0)
        {
            Console.WriteLine("Not divisible");
        }
        else
        {
            Console.WriteLine($"The number is divisible by {divNum}");
        }
    }
}
