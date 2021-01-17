using System;
using System.Collections.Generic;
using System.Threading;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = new List<string>();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                string[] name = Console.ReadLine().Split();
                if (names.Contains(name[0]) && name[1] == "is" && name[2] == "going!")
                {
                    Console.WriteLine($"{name[0]} is already in the list!");
                }
                else
                {
                    if (name[2] == "going!")
                    {
                        names.Add(name[0]);
                        count++;
                    }
                }
                if (count > 0)
                {
                    if (name[2] == "not")
                    {
                        if (!names.Contains(name[0]))
                        {
                            Console.WriteLine($"{name[0]} is not in the list!");
                        }
                        else
                        {
                            names.Remove(name[0]);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{name[0]} is not in the list!");
                }
            }
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
