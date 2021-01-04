using System;

namespace ConsoleApp54
{
    class Program
    {
        static void Main(string[] args)
        {
            double lostGameCount = double.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keybordPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetCount = 0;
            int mouseCount = 0;
            int keyboarCount = 0;
            int displayCount = 0;
            for (int i = 1; i <= lostGameCount; i++)
            {
                if (i % 2 == 0)
                {
                    headsetCount++;
                }
                if (i % 3 == 0)
                {
                    mouseCount++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboarCount++;
                }
                if (i % 12 == 0)
                {
                    displayCount++;
                }
            }
            double total = (headsetCount * headsetPrice) + (mouseCount * mousePrice) + (keyboarCount * keybordPrice) + (displayCount * displayPrice);
            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}
