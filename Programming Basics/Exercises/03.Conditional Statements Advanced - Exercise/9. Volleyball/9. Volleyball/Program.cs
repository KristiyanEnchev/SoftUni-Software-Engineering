using System;
class Program
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        double b = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double WLSF = ((48 - h) / 4) * 3;
        double ganmeB = (b / 3) * 2;
        double total = h + WLSF + ganmeB;
        if (year == "normal")
        {
            Console.WriteLine($"{Math.Floor(total)}");
        }
        else if (year == "leap")
        {
            double extra = total * 1.15;
            Console.WriteLine($"{Math.Floor(extra)}");
        }
    }
}
