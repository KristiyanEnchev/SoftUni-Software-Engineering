using System;
namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string numm = num.ToString();
            int total = 0;
            for (int i = 0; i < numm.Length; i++)
            {
                char r = numm[i];
                int t = int.Parse(r.ToString());
                int k = 1;
                for (int j = t; j >= 1; j--)
                {
                    k *= j;
                }
                total += k;
            }
            if (total == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
