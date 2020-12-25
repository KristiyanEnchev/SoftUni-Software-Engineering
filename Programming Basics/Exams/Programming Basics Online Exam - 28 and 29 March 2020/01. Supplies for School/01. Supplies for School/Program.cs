using System;
using System.Text;

namespace ConsoleApp28
{
    class Program
    {
        static void Main(string[] args)
        {
            int pen = int.Parse(Console.ReadLine());
            int marker = int.Parse(Console.ReadLine());
            double chemical = double.Parse(Console.ReadLine());
            double procentDiscount = double.Parse(Console.ReadLine());
            double procent = procentDiscount * 0.01;

            double totalPenPrice = pen * 5.80;
            double totalMarkerPrice = marker * 7.20;
            double totalChemicalPrice = chemical * 1.20;
            double totalPrice = totalPenPrice + totalMarkerPrice + totalChemicalPrice;
            double discount = totalPrice * procent;
            double total = totalPrice - discount;
            Console.WriteLine($"{total:f3}");
        }
    }
}
