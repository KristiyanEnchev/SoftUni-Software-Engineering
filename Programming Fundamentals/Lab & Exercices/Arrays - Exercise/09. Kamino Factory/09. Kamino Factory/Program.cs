using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        string comand = Console.ReadLine();

        int bestTotalLenght = 1;
        int bestStartIndex = 0;
        int bestSumm = 0;
        int index = 0;
        int[] final = new int[n];

        int count = 0;
        while (comand != "Clone them!")
        {
            int[] dna = comand.Split("!", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            count++;

            int lenght = 1;
            int bestLenght = 1;
            int startIndex = 0;
            int currentSum = 0;

            for (int i = 0; i < dna.Length - 1; i++)
            {
                if (dna[i] == dna[i + 1])
                {
                    lenght++;
                }
                else
                {
                    lenght = 1;
                }
                if (lenght > bestLenght)
                {
                    bestLenght = lenght;
                    startIndex = i;
                }
                currentSum += dna[i];
            }

            currentSum += dna[n - 1];

            if (bestLenght > bestTotalLenght)
            {
                bestTotalLenght = bestLenght;
                bestStartIndex = startIndex;
                bestSumm = currentSum;
                index = count;
                final = dna.ToArray();
            }
            else if (bestTotalLenght == bestLenght)
            {
                if (startIndex < bestStartIndex)
                {
                    bestTotalLenght = bestLenght;
                    bestStartIndex = startIndex;
                    bestSumm = currentSum;
                    index = count;
                    final = dna.ToArray();
                }
                else if (startIndex == bestStartIndex)
                {
                    if (currentSum > bestSumm)
                    {
                        bestTotalLenght = bestLenght;
                        bestStartIndex = startIndex;
                        bestSumm = currentSum;
                        index = count;
                        final = dna.ToArray();
                    }
                }
            }
            comand = Console.ReadLine();
        }
        Console.WriteLine($"Best DNA sample {index} with sum: {bestSumm}.");
        Console.WriteLine(string.Join(" ", final));
    }
}