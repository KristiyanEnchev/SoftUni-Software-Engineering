using System;

class Program
{
    static void Main(string[] args)
    {
        double lenght = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double hight = double.Parse(Console.ReadLine());
        string comand = Console.ReadLine();
        int box = 0;
        double cubic = lenght * hight * width;
        while (comand != "Done")
        {
            int count = int.Parse(comand);
            box += count;
            if (box > cubic)
            {
                Console.WriteLine($"No more free space! You need {box - cubic} Cubic meters more.");
                break;
            }
            comand = Console.ReadLine();
        }
        if (cubic < box)
        {

        }
        else
        {

            Console.WriteLine($"{cubic - box} Cubic meters left.");
        }
    }
}
