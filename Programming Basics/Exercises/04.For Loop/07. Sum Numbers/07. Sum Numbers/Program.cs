using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int n1 = int.Parse(Console.ReadLine());
            sum += n1;
        }
        Console.WriteLine(sum);
    }
}
