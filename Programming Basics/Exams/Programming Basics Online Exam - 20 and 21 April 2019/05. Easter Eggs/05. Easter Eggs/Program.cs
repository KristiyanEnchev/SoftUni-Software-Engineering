using System;

class Program
{
    static void Main(string[] args)
    {
        int eggCount = int.Parse(Console.ReadLine());
        int red = 0;
        int orange = 0;
        int blue = 0;
        int green = 0;
        while (eggCount != 0)
        {
            string color = Console.ReadLine();
            if (color == "red")
            {
                red++;
                eggCount--;
            }
            if (color == "orange")
            {
                orange++;
                eggCount--;
            }
            if (color == "blue")
            {
                blue++;
                eggCount--;
            }
            if (color == "green")
            {
                green++;
                eggCount--;
            }
        }
        Console.WriteLine($"Red eggs: {red}");
        Console.WriteLine($"Orange eggs: {orange}");
        Console.WriteLine($"Blue eggs: {blue}");
        Console.WriteLine($"Green eggs: {green}");
        if (red > blue && red > orange && red > green)
        {
            Console.WriteLine($"Max eggs: {red} -> {"red"}");
        }
        else if (blue > red && blue > orange && blue > green)
        {
            Console.WriteLine($"Max eggs: {blue} -> {"blue"}");
        }
        else if (orange > red && orange > blue && orange > green)
        {
            Console.WriteLine($"Max eggs: {orange} -> {"orange"}");
        }
        else if (green > red && green > blue && green > orange)
        {
            Console.WriteLine($"Max eggs: {green} -> {"green"}");
        }
    }
}