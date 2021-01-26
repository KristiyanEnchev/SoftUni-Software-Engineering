using System;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = Console.ReadLine().ToLower();
            string two = Console.ReadLine().ToLower();
            int index = two.IndexOf(one);

            while (two.Contains(one))
            {
                two = two.Remove(index, one.Length);

                index = two.IndexOf(one);
            }

            Console.WriteLine(two);
        }
    }
}
