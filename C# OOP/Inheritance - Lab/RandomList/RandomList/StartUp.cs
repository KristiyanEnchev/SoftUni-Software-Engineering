using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();

            list.Add("Pesho");
            list.Add("Gogo");
            list.Add("Lili");
            list.Add("Mari");
            list.Add("Misho");
            list.Add("Grogo");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(list.RandomString());
            }
        }
    }
}
