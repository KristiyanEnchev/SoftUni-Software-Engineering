using System;
using System.Collections.Generic;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> bombNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int specialNumber = bombNumbers[0];
            int bombPower = bombNumbers[1];
            while (numbers.Contains(specialNumber))
            {
                int index = numbers.IndexOf(specialNumber);
                if (index - bombPower >= 0 && index + bombPower <= numbers.Count - 1)
                {
                    for (int i = 0; i < index + bombPower + 1; i++)
                    {
                        if (i >= index - bombPower)
                        {
                            numbers.RemoveAt(index - bombPower);
                        }
                    }
                }
                else if (index - bombPower < 0 && index + bombPower <= numbers.Count - 1)
                {
                    for (int i = 0; i < index + bombPower + 1; i++)
                    {
                        numbers.RemoveAt(0);
                    }
                }
                else if (index + bombPower >= numbers.Count - 1 && index - bombPower >= 0)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (index - bombPower <= i)
                        {
                            numbers.RemoveAt(i);
                            i = -1;
                        }
                    }
                }
                else if (index - bombPower < 0 && index + bombPower >= numbers.Count)
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers.RemoveAt(i);
                        i = -1;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
