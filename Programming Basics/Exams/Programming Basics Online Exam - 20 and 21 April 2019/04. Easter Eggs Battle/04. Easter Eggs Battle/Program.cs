using System;

class Program
{
    static void Main(string[] args)
    {
        double eggsOne = double.Parse(Console.ReadLine());
        double eggsTwo = double.Parse(Console.ReadLine());

        string winer = Console.ReadLine();
        while (winer != "End of battle")
        {
            if (winer == "one")
            {
                eggsTwo--;
            }
            else if (winer == "two")
            {
                eggsOne--;
            }
            if (eggsOne == 0 || eggsTwo == 0)
            {
                break;
            }
            winer = Console.ReadLine();
        }
        if (winer == "End of battle")
        {
            Console.WriteLine($"Player one has {eggsOne} eggs left.");
            Console.WriteLine($"Player two has {eggsTwo} eggs left.");
        }
        else if (eggsOne == 0)
        {
            Console.WriteLine($"Player one is out of eggs. Player two has {eggsTwo} eggs left.");
        }
        else if (eggsTwo == 0)
        {
            Console.WriteLine($"Player two is out of eggs. Player one has {eggsOne} eggs left.");
        }
    }
}