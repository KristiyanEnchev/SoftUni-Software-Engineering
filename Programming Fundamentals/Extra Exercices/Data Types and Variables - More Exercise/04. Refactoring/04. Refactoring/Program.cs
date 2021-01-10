using System;

class Program
{
    static void Main(string[] args)
    {
        int numbersToBeCheked = int.Parse(Console.ReadLine());
        for (int firstPrimeNumber = 2; firstPrimeNumber <= numbersToBeCheked; firstPrimeNumber++)
        {
            bool isItPrime = true;
            for (int cepitel = 2; cepitel < firstPrimeNumber; cepitel++)
            {
                if (firstPrimeNumber % cepitel == 0)
                {
                    isItPrime = false;
                    break;
                }
            }
            Console.WriteLine("{0} -> {1}", firstPrimeNumber, isItPrime.ToString().ToLower());
        }

    }
}