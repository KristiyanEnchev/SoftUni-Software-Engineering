using System;

class Program
{
    static void Main(string[] args)
    {
        int numOne = int.Parse(Console.ReadLine());
        int numTwo = int.Parse(Console.ReadLine());
        int numThree = int.Parse(Console.ReadLine());

        Console.WriteLine(Comparision(numOne, numTwo, numThree));
    }

    static int Comparision(int one, int two, int three)
    {
        int result = 0;

        if (one <= two && one <= three)
        {
            result = one;
        }
        else if (two <= one && two <= three)
        {
            result = two;
        }
        else if (three <= one && three <= two)
        {
            result = three;
        }

        return result;
    }
}
