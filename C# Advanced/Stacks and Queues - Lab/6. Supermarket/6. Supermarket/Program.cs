using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var queu = new Queue<string>();
            string input = null;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (queu.Any())
                    {
                        Console.WriteLine(queu.Dequeue());
                    }
                }
                else
                {
                    queu.Enqueue(input);
                }
            }

            Console.WriteLine($"{queu.Count} people remaining.");
        }
    }
}