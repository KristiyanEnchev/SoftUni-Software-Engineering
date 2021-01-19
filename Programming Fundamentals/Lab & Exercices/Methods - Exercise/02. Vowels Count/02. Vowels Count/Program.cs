using System;

class Program
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine().ToLower();

        string cowelCount = VowolCountInTheWord(word);
        Console.WriteLine(cowelCount);
    }

    static string VowolCountInTheWord(string num)
    {
        int count = 0;

        for (int i = 0; i < num.Length; i++)
        {
            char letter = num[i];
            if (letter == 'a' || letter == 'e' ||
                letter == 'i' || letter == 'o' ||
                letter == 'u')
            {
                count++;
            }
        }

        return count.ToString();
    }
}
