using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace RegexEcercice
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double sum = 0;

            Console.WriteLine("Bought furniture:");

            while (input != "Purchase")
            {
                Match mach = regex.Match(input);

                if (mach.Success)
                {
                    string name = mach.Groups[1].Value;
                    double price = double.Parse(mach.Groups[2].Value);
                    int quantity = int.Parse(mach.Groups[3].Value);

                    Console.WriteLine(name);

                    sum += price * quantity;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
