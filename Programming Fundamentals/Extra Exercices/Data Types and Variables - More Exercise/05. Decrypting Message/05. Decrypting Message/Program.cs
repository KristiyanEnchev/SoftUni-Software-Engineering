using System;

class Program
{
    static void Main(string[] args)
    {
        int key = int.Parse(Console.ReadLine());
        int lineToFollow = int.Parse(Console.ReadLine());
        string message = "";
        for (int i = 1; i <= lineToFollow; i++)
        {
            char letters = char.Parse(Console.ReadLine());
            char result = (char)(letters + key);
            message += result;
        }
        Console.WriteLine(message);
    }
}