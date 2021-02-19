using System;
using System.Collections.Generic;
using System.Linq;
namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (var item in input)
            {

                if (dictionary.ContainsKey(item) == false)
                {
                    dictionary.Add(item, 0);
                }
                dictionary[item]++;
            }

            var list = dictionary.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                Console.WriteLine("{0}: {1} time/s", key, dictionary[key]);
            }
        }
    }
}
