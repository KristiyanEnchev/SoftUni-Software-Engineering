using System;
using System.Linq;
using System.Collections.Generic;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> boxOne = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> boxTwo = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int claimeditemsValue = 0;

            while (boxOne.Any() && boxTwo.Any())
            {
                int currentBoxOne = boxOne.Peek();
                int currentBoxTwo = boxTwo.Pop();
                int sum = currentBoxOne + currentBoxTwo;

                if (sum % 2 == 0)
                {
                    claimeditemsValue += sum;
                    boxOne.Dequeue();
                }
                else
                {
                    int[] array = new int[boxOne.Count + 1];
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        array[i] = boxOne.Dequeue();
                    }

                    array[array.Length -1] = currentBoxTwo;

                    foreach (var item in array)
                    {
                        boxOne.Enqueue(item);
                    }
                }
            }

            if (!boxOne.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimeditemsValue >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimeditemsValue}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimeditemsValue}");
            }
        }
    }
}
