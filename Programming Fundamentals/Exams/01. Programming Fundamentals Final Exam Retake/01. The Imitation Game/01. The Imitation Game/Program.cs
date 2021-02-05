using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string massage = Console.ReadLine();

            string comand = Console.ReadLine();
            while (comand != "Decode")
            {
                string[] input = comand.Split("|");
                string cmd = input[0];

                if (cmd == "Move")
                {
                    int count = int.Parse(input[1]);
                    string substring = massage.Substring(0, count);
                    massage = massage.Replace(substring, "");
                    massage = massage.Insert(massage.Length, substring);

                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(input[1]);
                    string substring = input[2];

                    massage = massage.Insert(index, substring);
                }
                else if (cmd == "ChangeAll")
                {
                    string substring = input[1];
                    string replacment = input[2];

                    massage = massage.Replace(substring, replacment);
                }

                comand = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {massage}");
        }
    }
}
