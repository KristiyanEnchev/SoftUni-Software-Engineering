using System;

class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());

        if (num <= 0)
        {
            Console.WriteLine(0);
        }
        else if (num == 1)
        {
            Console.Write(1);
        }
        else if (num == 2)
        {
            Console.Write("1 1");
        }
        else if (num == 3)
        {
            Console.Write("1 1 2");
        }
        else
        {
            Console.Write("1 1 2 ");
            GetTribonacci(num);
        }
    }

    private static void GetTribonacci(int num)
    {
        int three = 1;
        int two = 1;
        int one = 2;
        int max = num;
        for (int i = 0; i < max - 3; i++)
        {
            num = three + two + one;
            three = two;
            two = one;
            one = num;
            Console.Write("{0} ", num);
        }
    }
}