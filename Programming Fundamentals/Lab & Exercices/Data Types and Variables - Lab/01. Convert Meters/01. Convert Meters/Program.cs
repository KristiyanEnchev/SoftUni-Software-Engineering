using System;

class Program
{
    static void Main(string[] args)
    {
        int metters = int.Parse(Console.ReadLine());
        decimal kilometers = metters / 1000m;
        Console.WriteLine($"{kilometers:f2}");
    }
}
