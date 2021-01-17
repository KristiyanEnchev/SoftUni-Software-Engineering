using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Exercise_8_9_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> uncnown = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string comand = Console.ReadLine();
            while (comand != "3:1")
            {
                string[] input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "merge")
                {
                    int start = int.Parse(input[1]);
                    int end = int.Parse(input[2]);
                    Merge(uncnown, start, end);

                }
                else if (input[0] == "divide")
                {
                    int index = int.Parse(input[1]);
                    int partition = int.Parse(input[2]);
                    Divide(uncnown, index, partition);

                }

                comand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", uncnown));
        }

        static void Merge(List<string> uncnown, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (endIndex > uncnown.Count - 1)
            {
                endIndex = uncnown.Count - 1;
            }

            for (int j = startIndex + 1; j <= endIndex; j++)
            {
                uncnown[startIndex] += uncnown[startIndex + 1];
                uncnown.RemoveAt(startIndex + 1);
            }
        }

        static void Divide(List<string> uncnown, int index, int partition)
        {
            string objject = uncnown[index];
            uncnown.RemoveAt(index);
            int pieceLenght = objject.Length / partition;
            int expraParts = objject.Length % partition;

            List<string> type = new List<string>(objject.Length);

            for (int i = 0; i < partition; i++)
            {
                string adding = string.Empty;
                for (int j = 0; j < pieceLenght; j++)
                {
                    adding += objject[(i * pieceLenght) + j];
                }
                if (i == partition - 1 && expraParts != 0)
                {
                    adding += objject.Substring(objject.Length - expraParts);
                }
                type.Add(adding);
            }

            uncnown.InsertRange(index, type);
        }
    }
}
