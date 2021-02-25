using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double value = double.Parse(Console.ReadLine());
            Box<double> comparableBox = new Box<double>(value);
            double count = GetGreaterThanCount(boxes, comparableBox);

            Console.WriteLine(count);

        }

        private static double GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in boxes)
            {
                int compare = item.Value.CompareTo(box.Value);

                if (compare > 0)
                {
                    count++;
                }
            }

            return count;
        }
        private static void SwapIndexes<T>(List<Box<T>> boxes, int firtsindex, int secondIndex)
            where T : IComparable
        {
            Box<T> temp = boxes[firtsindex];
            boxes[firtsindex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}