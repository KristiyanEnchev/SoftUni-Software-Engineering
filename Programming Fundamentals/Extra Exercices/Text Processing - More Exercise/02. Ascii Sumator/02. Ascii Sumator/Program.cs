using System;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());

            int numOne = one;
            int numTwo = two;

            string massage = Console.ReadLine();

            int total = 0;

            for (int i = 0; i < massage.Length; i++)
            {
                char charecter = massage[i];
                int num = charecter;
                if (num > one && num < two || num > two && num < one)
                {
                    total += num;
                }
            }

            Console.WriteLine(total);
        }
    }
}
