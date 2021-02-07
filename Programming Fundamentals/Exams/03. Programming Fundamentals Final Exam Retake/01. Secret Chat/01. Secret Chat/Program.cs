using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_prrepp_12_12_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string massege = Console.ReadLine();

            string comand = Console.ReadLine();
            while (comand != "Reveal")
            {
                string[] input = comand.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string cmd = input[0];
                string substring = string.Empty;

                switch (cmd)
                {
                    case "InsertSpace":
                        int index = int.Parse(input[1]);
                        massege = massege.Insert(index, " ");

                        Console.WriteLine(massege);
                        break;
                    case "Reverse":
                        substring = input[1];
                        if (massege.Contains(substring))
                        {
                            int indexer = massege.IndexOf(substring);
                            char[] newSub = substring.ToCharArray();
                            Array.Reverse(newSub);
                            substring = new string(newSub);

                            massege = massege.Remove(indexer, substring.Length);
                            massege = massege.Insert(massege.Length, substring);

                            Console.WriteLine(massege);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        substring = input[1];
                        string replacment = input[2];

                        massege = massege.Replace(substring, replacment);

                        Console.WriteLine(massege);
                        break;
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {massege}");
        }
    }
}
