using System;

namespace ConsoleApp55
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            string output = "";

            for (int i = comand.Length - 1; i >= 0; i--)
            {
                output += comand[i];
            }
            Console.WriteLine(output);
        }
    }
}
