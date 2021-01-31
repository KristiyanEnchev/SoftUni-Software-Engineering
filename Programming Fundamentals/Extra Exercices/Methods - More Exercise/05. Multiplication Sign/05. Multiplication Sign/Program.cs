using System;

class Program
{
    static void Main(string[] args)
    {
        int numOne = int.Parse(Console.ReadLine());
        int numTwo = int.Parse(Console.ReadLine());
        int numThree = int.Parse(Console.ReadLine());

        PrintPositiveOrNegativeOrZero(numOne, numTwo, numThree);
    }

    public static void PrintPositiveOrNegativeOrZero(int one, int two, int three)
    {
        if (one < 0 || two < 0 || three < 0)
        {
            if (one == 0 || two == 0 || three == 0)
            {
                Console.WriteLine("zero");
            }
            else if (one < 0 && two < 0 && three > 0 || one < 0 && three < 0 && two > 0 || two < 0 && three < 0 && one > 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
        else
        {
            if (one == 0 || two == 0 || three == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}