using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> productList = new List<string>(num);

            for (int i = 0; i < num; i++)
            {
                string product = Console.ReadLine();
                productList.Add(product);
            }

            productList.Sort();
            int number = 0;
            for (int i = 0; i < productList.Count; i++)
            {
                number += 1;
                productList[i] = $"{number}.{productList[i]}";
            }

            Console.WriteLine(string.Join(Environment.NewLine, productList));
        }
    }
}
