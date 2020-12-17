using System;

namespace ConsoleApp44
{
    class Program
    {
        static void Main(string[] args)
        {
            char from = char.Parse(Console.ReadLine());
            char to = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());
            int count = 0;
            for (char j = from; j <= to; j++)
            {
                for (char k = from; k <= to; k++)
                {
                    for (char l = from; l <= to; l++)
                    {
                        if (j != skip && k != skip && l != skip)
                        {
                            Console.Write($"{j}{k}{l} ");
                            count++;
                        }
                    }
                }
            }
            Console.Write(count);
        }
    }
}