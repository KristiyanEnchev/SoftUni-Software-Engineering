using System;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            if (comand == "sunny")
            {
                Console.WriteLine("It's warm outside!");
            }
            else
            {
                Console.WriteLine("It's cold outside!");
            }
        }
    }
}
