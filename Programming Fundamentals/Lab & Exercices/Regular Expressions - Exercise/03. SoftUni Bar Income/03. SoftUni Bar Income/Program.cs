using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z]{1}[a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            double total = 0;

            while (input != "end of shift")
            {
                Match mach = regex.Match(input);

                if (mach.Success)
                {
                    string costomur = mach.Groups[1].Value;
                    string product = mach.Groups[2].Value;
                    int count = int.Parse(mach.Groups[3].Value);
                    double price = double.Parse(mach.Groups[4].Value);

                    double sum = count * price;
                    total += sum;

                    Console.WriteLine($"{costomur}: {product} - {sum:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
