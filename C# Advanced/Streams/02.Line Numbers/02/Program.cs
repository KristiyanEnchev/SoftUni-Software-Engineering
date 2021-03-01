using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine("..", "..", "..", "output.txt");
            string[] lines = File.ReadAllLines("text.txt");
            List<char> punctuationMarck = new List<char>() { '-', ',', '.', '!', '?', '\'' };
            List<string> newLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int letters = 0;
                int punctuationCount = 0;

                foreach (var item in line)
                {
                    if (char.IsLetter(item))
                    {
                        letters++;
                    }
                    else if (punctuationMarck.Contains(item))
                    {
                        punctuationCount++;
                    }
                }

                string newLine = $"Line {i+1}: {line} ({letters})({punctuationCount})";
                newLines.Add(newLine);

            }
                Console.WriteLine(string.Join(Environment.NewLine, newLines));
                File.WriteAllLines(outputPath, newLines);
        }
    }
}
