using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList();
            ListyIterator<string> List = new ListyIterator<string>(items);

            string comand = Console.ReadLine();
            while (comand != "END")
            {
                switch (comand)
                {
                    case"Move":
                        Console.WriteLine(List.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(List.HasNext());
                        break;
                    case "Print":
                        List.Print();
                        break;
                }


                comand = Console.ReadLine();
            }
        }
    }
}
