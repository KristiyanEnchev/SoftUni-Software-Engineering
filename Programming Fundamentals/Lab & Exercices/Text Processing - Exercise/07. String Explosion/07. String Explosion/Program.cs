using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int power = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '>')
                {
                    power += int.Parse(line[i + 1].ToString());
                    continue;
                }

                if (power > 0)
                {
                    line = line.Remove(i, 1);
                    i--;
                    power--;
                }
            }

            Console.WriteLine(line);
        }
    }
}
