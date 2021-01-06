using System;

class Program
{
    static void Main(string[] args)
    {
        char letter = char.Parse(Console.ReadLine());
        int digit = (int)letter;
        if (digit > 64 && digit < 91)
        {
            Console.WriteLine("upper-case");
        }
        else if (digit > 96 && digit < 123)
        {
            Console.WriteLine("lower-case");
        }
    }
}
