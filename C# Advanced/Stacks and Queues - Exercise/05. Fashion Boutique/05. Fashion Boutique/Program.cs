using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] allClothesInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> allClothes = new Stack<int>(allClothesInput);

            int boxCapacity = int.Parse(Console.ReadLine());
            int curentBoxCap = boxCapacity;
            int racksCount = 1;

            while (allClothes.Any())
            {
                int clothes = allClothes.Pop();

                curentBoxCap -= clothes;

                if (curentBoxCap < 0)
                {
                    racksCount++;
                    curentBoxCap = boxCapacity;
                    curentBoxCap -= clothes;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
