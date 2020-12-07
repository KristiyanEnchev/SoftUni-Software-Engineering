using System;
class Program
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();
        int len = text.Length;
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(text[i]);
        }

    }
}
