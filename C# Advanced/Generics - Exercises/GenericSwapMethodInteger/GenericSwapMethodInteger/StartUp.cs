using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            int[] indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            SwapIndexes(boxes, indexes[0], indexes[1]);

            foreach (var curentBox in boxes)
            {
                Console.WriteLine(curentBox);
            }
        }

        private static void SwapIndexes<T>(List<Box<T>> boxes, int firtsindex, int secondIndex)
        {
            Box<T> temp = boxes[firtsindex];
            boxes[firtsindex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}
