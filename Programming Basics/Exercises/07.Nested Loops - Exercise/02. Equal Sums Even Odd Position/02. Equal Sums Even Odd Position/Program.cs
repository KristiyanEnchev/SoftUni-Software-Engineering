using System;
class Program
{
    static void Main(string[] args)
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());

        for (int i = first; i <= second; i++)
        {
            string num = i.ToString();
            int even = 0;
            int odd = 0;
            for (int j = 0; j < num.Length; j++)
            {
                int digit = int.Parse(num[j].ToString());
                if (j % 2 == 0)
                {
                    even += digit;
                }
                else
                {
                    odd += digit;
                }
            }
            if (even == odd)
            {
                Console.Write(i + " ");
            }
        }
    }
}
