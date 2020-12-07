using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i <= n; i += 2)
        {
            double result = Math.Pow(2, i);
            Console.WriteLine(result);
        }
    }
}
