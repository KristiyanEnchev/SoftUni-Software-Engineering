using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLIne = "../../../text.txt";
            //string fileline = Path.Combine("..","..","..", "text.txt");
            using (StreamReader reader = new StreamReader(fileLIne))
            {
                int count = 0;
                string chars = "-,.!?";
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (count % 2 == 0)
                    {
                        foreach (var item in chars)
                        {
                            line = line.Replace(item, '@');
                        }
                        string[] splittedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", splittedLine));
                    }
                    count++;

                }
            }
        }
    }
}
