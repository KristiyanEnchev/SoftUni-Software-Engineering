using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cups = Console.ReadLine().Split().Select(int.Parse).Reverse();
            var bottles = Console.ReadLine().Split().Select(int.Parse);

            var cupsStack = new Stack<int>(cups);
            var bottlesStack = new Stack<int>(bottles);
            var wastedLiters = 0;

            while (cupsStack.Count != 0 && bottlesStack.Count != 0)
            {
                var bottleSize = bottlesStack.Pop();
                var cupSize = cupsStack.Pop();


                if (cupSize > bottleSize)
                {
                    var fillUp = cupSize - bottleSize;
                    cupsStack.Push(fillUp);
                }
                else
                {
                    wastedLiters += bottleSize - cupSize;
                }
            }

            if (bottlesStack.Count != 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
            else
            {

                Console.WriteLine($"Cups: {string.Join(" ", cupsStack)}");
                Console.WriteLine($"Wasted litters of water: {wastedLiters}");
            }
        }
    }
}