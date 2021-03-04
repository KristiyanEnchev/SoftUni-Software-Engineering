using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp57
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse).ToArray());

            int wreaths = 0;
            int flowers = 0;

            while (roses.Any() && lilies.Any())
            {
                int lili = lilies.Pop();
                int rose = roses.Dequeue();

                while (true)
                {
                    int sum = lili + rose;
                    if (sum == 15)
                    {
                        wreaths++;
                        break;
                    }
                    else if (sum < 15)
                    {
                        flowers += sum;
                        break;
                    }
                    else
                    {
                        lili -= 2;
                    }
                }
            }

            wreaths += flowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }

        }
    }
}
