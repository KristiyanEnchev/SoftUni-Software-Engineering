using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] cmdArg = input.Split();
                string comand = cmdArg[0];

                if (comand == "TakeOdd")
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            sb.Append(password[i]);
                        }
                    }

                    password = sb.ToString();

                    Console.WriteLine(password);
                }
                else if (comand == "Cut")
                {
                    int index = int.Parse(cmdArg[1]);
                    int lenght = int.Parse(cmdArg[2]);

                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (comand == "Substitute")
                {
                    string substring = cmdArg[1];
                    string substitute = cmdArg[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
