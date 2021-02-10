using System;

namespace Exam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialEmail = Console.ReadLine();

            string comand = Console.ReadLine();
            while (comand != "Complete")
            {
                string[] input = comand.Split(" ");
                string cmd = input[0];

                if (cmd == "Make")
                {
                    if (input[1] == "Upper")
                    {
                        initialEmail = initialEmail.ToUpper();
                        Console.WriteLine(initialEmail);
                    }
                    else if (input[1] == "Lower")
                    {
                        initialEmail = initialEmail.ToLower();
                        Console.WriteLine(initialEmail);
                    }
                }
                else if (cmd == "GetDomain")
                {
                    int count = int.Parse(input[1]);

                    int startIndex = initialEmail.Length - count;
                    string domain = string.Empty;

                    for (int i = startIndex; i < initialEmail.Length; i++)
                    {
                        domain += initialEmail[i];
                    }

                    Console.WriteLine(domain);
                }
                else if (cmd == "GetUsername")
                {
                    if (initialEmail.Contains("@"))
                    {
                        int index = initialEmail.IndexOf("@");

                        string substring = initialEmail.Substring(0, index);

                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {initialEmail} doesn't contain the @ symbol.");
                    }
                }
                else if (cmd == "Replace")
                {
                    string substring = input[1];

                    initialEmail = initialEmail.Replace(substring, "-");

                    Console.WriteLine(initialEmail);
                }
                else if (cmd == "Encrypt")
                {
                    for (int i = 0; i < initialEmail.Length; i++)
                    {
                        int value = initialEmail[i];
                        Console.Write(value + " ");
                    }
                    Console.WriteLine();
                }

                comand = Console.ReadLine();
            }
        }
    }
}
