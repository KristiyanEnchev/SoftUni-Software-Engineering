using System;

class Program
{
    static void Main(string[] args)
    {
        decimal pound = decimal.Parse(Console.ReadLine());
        decimal dolar = pound * 1.31m;
        Console.WriteLine($"{dolar:f3}");
    }
}
