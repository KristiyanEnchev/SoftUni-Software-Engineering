using System;

class Program
{
    static void Main(string[] args)
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        string delimiter = Console.ReadLine();
        Console.Write($"{firstName}{delimiter}{lastName}");
    }
}
