using System;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string word = Console.ReadLine();
                if (word == "Stop")
                {
                    break;
                }
                Console.WriteLine(word);
            }
        }
    }
}
