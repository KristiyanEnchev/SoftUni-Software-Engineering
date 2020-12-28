using System;

namespace ConsoleApp52
{
    class Program
    {
        static void Main(string[] args)
        {
            double pencilCount = double.Parse(Console.ReadLine());
            double colorPenCount = double.Parse(Console.ReadLine());
            double drawindBookCount = double.Parse(Console.ReadLine());
            double noteBookCount = double.Parse(Console.ReadLine());
            double pencil = pencilCount * 4.75;
            double colorPen = colorPenCount * 1.80;
            double drawingBook = drawindBookCount * 6.50;
            double noteBook = noteBookCount * 2.50;
            double total = pencil + colorPen + drawingBook + noteBook;
            double finalTotal = total - ((total * 5) / 100);
            Console.WriteLine($"Your total is {finalTotal:f2}lv");
        }
    }
}
