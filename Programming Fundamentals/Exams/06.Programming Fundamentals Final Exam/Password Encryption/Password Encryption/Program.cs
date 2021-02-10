using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Exam_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string pattern = @"(.*)([\>]{1})(?<password>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]+))([<])\1$";


            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(pattern);
                Match mach = regex.Match(input);

                if (mach.Success)
                {
                    string password = mach.Groups["password"].Value.Replace("|", "");

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }

            }

        }
    }
}
