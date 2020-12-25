using System;
namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoinCount = int.Parse(Console.ReadLine());
            double chineseUana = double.Parse(Console.ReadLine());
            double comisionProcent = double.Parse(Console.ReadLine());

            double procent = comisionProcent * 0.01;
            double UanaInEuro = ((chineseUana * 0.15) * 1.76) / 1.95;
            double bitcoinInEuro = (bitcoinCount * 1168) / 1.95;
            double totalMoney = bitcoinInEuro + UanaInEuro;
            double totalAfterComision = totalMoney - (totalMoney * procent);

            Console.WriteLine($"{totalAfterComision:f2}");
        }
    }
}