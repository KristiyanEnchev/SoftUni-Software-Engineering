using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string massage = Console.ReadLine();

            //string pattern = @"([\@]|[\#])([A-Za-z]{3,})\1";
            //string pattern = @"([\@]|[\#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1";
            string pattern = @"([\@]|[\#])(([A-Za-z]{3,})\1\1([A-Za-z]{3,}))\1";

            Regex regex = new Regex(pattern);

            List<string> maches = new List<string>();

            foreach (Match item in regex.Matches(massage))
            {
                maches.Add(item.Groups[2].Value);
            }

            if (maches.Count <= 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{maches.Count} word pairs found!");

                for (int i = 0; i < maches.Count; i++)
                {
                    if (maches[i].Contains("@@"))
                    {
                        string[] split = maches[i].Split("@@");
                        char[] mirror = split[1].ToCharArray();
                        Array.Reverse(mirror);
                        string chek = new string(mirror);
                        int index = maches.IndexOf(maches[i]);

                        if (split[0] == chek)
                        {
                            string substring = "@@";
                            maches[i] = maches[i].Replace(substring, " <=> ");
                        }
                        else
                        {
                            maches.RemoveAt(i);
                            i -= 1;
                        }
                    }
                    else if (maches[i].Contains("##"))
                    {
                        string[] split = maches[i].Split("##");
                        char[] mirror = split[1].ToCharArray();
                        Array.Reverse(mirror);
                        string chek = new string(mirror);
                        int index = maches.IndexOf(maches[i]);

                        if (split[0] == chek)
                        {
                            string substring = "##";
                            maches[i] = maches[i].Replace(substring, " <=> ");
                        }
                        else
                        {
                            maches.RemoveAt(i);
                            i -= 1;
                        }
                    }
                }

                if (maches.Count <= 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", maches));
                }
            }

        }
    }
}
