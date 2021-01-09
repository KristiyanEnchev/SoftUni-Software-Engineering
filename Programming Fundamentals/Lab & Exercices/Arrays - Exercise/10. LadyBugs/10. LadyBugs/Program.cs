using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int[] ladyBug = new int[fieldSize];
        int[] initialIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int i = 0; i < initialIndexes.Length; i++)
        {
            if (initialIndexes[i] >= 0 && initialIndexes[i] < fieldSize)
            {
                ladyBug[initialIndexes[i]] = 1;
            }
        }

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int ladyBugIndex = int.Parse(command[0]);
            int flyLength = int.Parse(command[2]);

            if (ladyBugIndex >= 0 && ladyBugIndex < fieldSize && ladyBug[ladyBugIndex] == 1)
            {
                ladyBug[ladyBugIndex] = 0;
                if (flyLength == 0)
                {
                    ladyBug[ladyBugIndex] = 1;
                    continue;
                }
            }
            else if (ladyBugIndex < 0 || ladyBugIndex >= fieldSize || ladyBug[ladyBugIndex] == 0)
            {
                continue;
            }
            if (command[1] == "left")
            {
                while (ladyBugIndex - flyLength >= 0 && ladyBugIndex - flyLength < fieldSize)
                {
                    if (ladyBug[ladyBugIndex - flyLength] == 0)
                    {
                        ladyBug[ladyBugIndex - flyLength] = 1;
                        break;
                    }
                    else
                    {
                        ladyBugIndex -= flyLength;
                    }
                }
            }
            else if (command[1] == "right")
            {
                while ((ladyBugIndex + flyLength >= 0 && ladyBugIndex + flyLength < fieldSize))
                {
                    if (ladyBug[ladyBugIndex + flyLength] == 0)
                    {
                        ladyBug[ladyBugIndex + flyLength] = 1;
                        break;
                    }
                    else
                    {
                        ladyBugIndex += flyLength;
                    }
                }
            }
        }
        Console.WriteLine(string.Join(" ", ladyBug));
    }
}