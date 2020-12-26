using System;

namespace ConsoleApp46
{
    class Program
    {
        static void Main(string[] args)
        {
            double procesorPrice = double.Parse(Console.ReadLine());
            double videoCardPrice = double.Parse(Console.ReadLine());
            double ramPrice = double.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double procesorInLeva = procesorPrice * 1.57;
            double videoInLeva = videoCardPrice * 1.57;
            double ramInLeva = ramPrice * 1.57;
            double totalRam = ramInLeva * ramCount;
            double procesorDiscount = procesorInLeva * discount;
            double videoDiscount = videoInLeva * discount;
            double totalPricesorPrice = procesorInLeva - procesorDiscount;
            double totalvideo = videoInLeva - videoDiscount;
            double total = totalPricesorPrice + totalvideo + totalRam;
            Console.WriteLine($"Money needed - {total:f2} leva.");
        }
    }
}
