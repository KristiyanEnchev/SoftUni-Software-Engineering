using System;
class Program
{
    static void Main(string[] args)
    {
        int stores = int.Parse(Console.ReadLine());
        int rooms = int.Parse(Console.ReadLine());
        string type = "";
        for (int rows = stores; rows >= 1; rows--)
        {
            for (int colums = 0; colums < rooms; colums++)
            {
                if (rows == stores)
                {
                    type = "L";
                }
                else
                {
                    if (rows % 2 == 0)
                    {
                        type = "O";
                    }
                    else
                    {
                        type = "A";
                    }
                }
                Console.Write($"{type}{rows}{colums} ");
            }
            Console.WriteLine();
        }
    }
}
