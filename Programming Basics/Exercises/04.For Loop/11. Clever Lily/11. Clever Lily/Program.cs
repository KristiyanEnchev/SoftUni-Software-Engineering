using System;

class Program
{
    static void Main(string[] args)
    {
        int age = int.Parse(Console.ReadLine());
        double priceMachine = double.Parse(Console.ReadLine());
        double priceToy = double.Parse(Console.ReadLine());
        double savings = 0;
        double money = 10;
        double toys = 0;
        for (int i = 1; i <= age; i++)
        {
            if (i % 2 == 0)
            {
                savings += money;
                savings -= 1;
                money += 10;
            }
            else
            {
                toys += 1;
            }
        }
        double total = savings + (toys * priceToy);
        if (total >= priceMachine)
        {
            double extra = total - priceMachine;
            Console.WriteLine($"Yes! {extra:f2}");
        }
        else
        {
            double need = priceMachine - total;
            Console.WriteLine($"No! {need:f2}");
        }
    }
}
