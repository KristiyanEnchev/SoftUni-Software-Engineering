using System;

class Program
{
    static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int count = 0;
        string pass = "";
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
            {
                for (int k = 1; k <= 9; k++)
                {
                    for (int l = 1; l <= 9; l++)
                    {
                        if (i < j && k > l)
                        {
                            if (i * j + k * l == m)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                                count++;
                                if (count == 4)
                                {
                                    pass = $"{i}{j}{k}{l}";
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine();
        if (count >= 4)
        {
            Console.WriteLine($"Password: {pass}");
        }
        else
        {
            Console.WriteLine("No!");
        }
    }
}
