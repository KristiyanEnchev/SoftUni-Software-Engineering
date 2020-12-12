using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int num = 1;
        bool end = false;
        for (int row = 1; row <= n; row++)
        {
            for (int colums = 1; colums <= row; colums++)
            {
                if (num > n)
                {
                    end = true;
                    break;
                }
                Console.Write(num + " ");
                num++;
            }
            if (end)
            {
                break;
            }
            Console.WriteLine();
        }
    }
}
