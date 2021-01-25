using System;
using System.Linq;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            string massege = Console.ReadLine();

            for (int i = 0; i < massege.Length - 1; i++)
            {
                if (massege[i] == massege[i + 1])
                {
                    massege = massege.Remove(i + 1, 1);
                    i -= 1;
                }
            }

            Console.WriteLine(massege);
        }
    }
}
