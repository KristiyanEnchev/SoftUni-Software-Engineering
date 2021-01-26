using System;
using System.Linq;

namespace Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string newWord = string.Empty;
                for (int i = comand.Length - 1; i >= 0; i--)
                {
                    newWord += comand[i];
                }

                Console.WriteLine($"{comand} = {newWord}");

                comand = Console.ReadLine();
            }
        }
    }
}
