using System;
using System.Linq;

namespace ConsoleApp75
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double total = 0;

            foreach (var item in array)
            {
                string letters = string.Empty;
                letters += item[0];
                letters += item[item.Length - 1];
                string newItem = item.Remove(0, 1);
                newItem = newItem.Remove(newItem.Length - 1, 1);
                int number = int.Parse(newItem);

                for (int i = 0; i < letters.Length; i++)
                {
                    if (i == 0 && char.IsUpper(letters[i]))
                    {
                        double position = letters[i] - 64;

                        total += number / position;
                    }
                    else if (i == 0 && char.IsLower(letters[i]))
                    {
                        double position = letters[i] - 96;

                        total += number * position;
                    }

                    if (i == letters.Length - 1 && char.IsUpper(letters[i]))
                    {
                        double position = letters[i] - 64;

                        total = total - position;
                    }
                    else if (i == letters.Length - 1 && char.IsLower(letters[i]))
                    {

                        double position = letters[i] - 96;

                        total = total + position;
                    }
                }
            }

            Console.WriteLine($"{total:f2}");
        }
    }
}
