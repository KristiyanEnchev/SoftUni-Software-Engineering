using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfoperations = int.Parse(Console.ReadLine());
        int counterOpen = 0;
        int counterClose = 0;
        for (int i = 1; i <= numberOfoperations; i++)
        {
            string operation = Console.ReadLine();
            if (operation == "(")
            {
                counterOpen++;
            }
            else if (operation == ")")
            {
                counterClose++;
                if (counterOpen - counterClose != 0)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
            }
        }
        if (counterClose == counterOpen)
        {
            Console.WriteLine("BALANCED");
        }
        else
        {
            Console.WriteLine("UNBALANCED");
        }
    }
}