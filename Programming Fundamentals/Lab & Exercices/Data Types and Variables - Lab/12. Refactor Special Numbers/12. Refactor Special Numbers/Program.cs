using System;

class Program
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        for (int i = 1; i <= num; i++)
        {
            int summ = 0;
            Console.Write($"{i} -> ");
            for (int j = 0; j < i.ToString().Length; j++)
            {
                int nummm = int.Parse(i.ToString()[j].ToString());
                summ += nummm;
            }
            if (summ == 5 || summ == 7 || summ == 11)
            {
                Console.Write("True");
            }
            else
            {
                Console.Write("False");
            }
            Console.WriteLine();
        }
    }
}
