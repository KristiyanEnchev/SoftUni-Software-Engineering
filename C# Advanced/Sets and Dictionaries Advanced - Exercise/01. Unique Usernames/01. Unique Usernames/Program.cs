using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> hashset = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                hashset.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", hashset));
        }
    }
}
