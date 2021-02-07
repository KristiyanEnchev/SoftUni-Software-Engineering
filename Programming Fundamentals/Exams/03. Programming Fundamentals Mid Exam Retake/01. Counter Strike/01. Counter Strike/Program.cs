using System;

namespace Exam_Prep_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int count = 0;

            string comand = Console.ReadLine();
            while (comand != "End of battle")
            {
                int enemy = int.Parse(comand);
                if (num < enemy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {num} energy");
                    Environment.Exit(0);
                }
                else
                {
                    num -= enemy;
                    count++;
                    if (count % 3 == 0)
                    {
                        num += count;
                    }
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine($"Won battles: {count}. Energy left: {num}");
        }
    }
}
