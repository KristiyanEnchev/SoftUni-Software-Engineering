using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Demon> allDemons = new List<Demon>();

            string pattern = @"[-+]?[0-9]+\.?[0-9]*";

            Regex numbersReg = new Regex(pattern);

            string[] demons = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var demon in demons)
            {
                string filter = "1234567890-/+.*";
                int helth = demon.Where(x => !filter.Contains(x)).Sum(x => x);

                double damage = CalculateDamage(numbersReg, demon);

                allDemons.Add(new Demon { Name = demon, Helth = helth, Damage = damage });
            }

            foreach (var demon in allDemons.OrderBy(x => x.Name))
            {
                Console.WriteLine(demon);
            }
        }

        private static double CalculateDamage(Regex numbersReg, string demon)
        {
            MatchCollection numberMaches = numbersReg.Matches(demon);
            double damege = 0;

            foreach (Match mach in numberMaches)
            {
                damege += double.Parse(mach.Value);
            }

            foreach (var ch in demon)
            {
                if (ch == '*')
                {
                    damege *= 2.0;
                }
                else if (ch == '/')
                {
                    damege /= 2.0;
                }
            }
            return damege;
        }
    }

    class Demon
    {
        public string Name { get; set; }
        public int Helth { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Helth} health, {Damage:f2} damage";
        }
    }
}
