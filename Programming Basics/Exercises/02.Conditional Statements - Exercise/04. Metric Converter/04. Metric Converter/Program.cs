using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string metric = Console.ReadLine();
            string metric2 = Console.ReadLine();
            double count = 0;
            if (metric == "mm" && metric2 == "cm")
            {
                count = num / 10;
            }
            else if (metric == "mm" && metric2 == "m")
            {
                count = num / 1000;
            }
            else if (metric == "cm" && metric2 == "m")
            {
                count = num / 100;
            }
            else if (metric == "cm" && metric2 == "mm")
            {
                count = num * 10;
            }
            else if (metric == "m" && metric2 == "cm")
            {
                count = num * 100;
            }
            else if (metric == "m" && metric2 == "mm")
            {
                count = num * 1000;
            }
            else
            {
                count = num;
            }
            Console.WriteLine($"{count:f3}");
        }
    }
}
