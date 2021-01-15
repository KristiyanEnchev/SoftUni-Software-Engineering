using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();

            for (int i = 0; i < num; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (!dic.ContainsKey(word))
                {
                    dic.Add(word, new List<string>());
                    dic[word].Add(synonim);
                }
                else
                {
                    dic[word].Add(synonim);
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
