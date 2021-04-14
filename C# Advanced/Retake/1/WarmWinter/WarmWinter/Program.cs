using System;
using System.Linq;
using System.Collections.Generic;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            List<int> set = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    set.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }

                if (scarf > hat)
                {
                    hats.Pop();
                    continue;
                }

                if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hat += 1;
                    hats.Pop();
                    hats.Push(hat);
                }
            }

            int theMostExpensive = set.OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"The most expensive set is: {theMostExpensive}");

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
