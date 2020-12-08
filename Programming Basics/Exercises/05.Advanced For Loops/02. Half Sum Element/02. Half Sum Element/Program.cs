using System;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int max = int.MinValue;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            sum += num;
            if (num > max)
            {
                max = num;
            }
        }
        if (sum - max == max)
        {
            Console.WriteLine("Yes");
            Console.WriteLine($"Sum = {max}");
        }
        else
        {
            double dif = (sum - max) - max;
            Console.WriteLine("No");
            Console.WriteLine($"Diff = {Math.Abs(dif)}");
        }
    }
}
