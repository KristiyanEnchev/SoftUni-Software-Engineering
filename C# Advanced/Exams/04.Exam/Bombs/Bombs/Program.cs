using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effect = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Stack<int> casing = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int datureBomb = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            bool isSucsessful = false;

            while (effect.Any() && casing.Any())
            {
                int curentEffect = effect.Peek();
                int curentCasing = casing.Peek();
                int sum = curentCasing + curentEffect;

                if (sum == 40)
                {
                    datureBomb++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyBombs++;
                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    int newValue = casing.Pop() - 5;
                    int[] array = new int[casing.Count + 1];
                    array[0] = newValue;
                    for (int i = 1; i < array.Length; i++)
                    {
                        array[i] = casing.Pop();
                    }

                    array = array.Reverse().ToArray();
                    foreach (var item in array)
                    {
                        casing.Push(item);
                    }

                }

                if (datureBomb >= 3 && smokeDecoyBombs >= 3 && cherryBombs >= 3)
                {
                    isSucsessful = true;
                    break;
                }
            }

            if (isSucsessful)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {datureBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}
