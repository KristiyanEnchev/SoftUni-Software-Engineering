using System;

class Program
{
    static void Main(string[] args)
    {
        int tabs = int.Parse(Console.ReadLine());
        double salary = double.Parse(Console.ReadLine());
        for (int i = 1; i <= tabs; i++)
        {
            string website = Console.ReadLine();
            if (website == "Facebook")
            {
                salary -= 150;
            }
            else if (website == "Instagram")
            {
                salary -= 100;
            }
            else if (website == "Reddit")
            {
                salary -= 50;
            }
        }
        if (salary <= 0)
        {
            Console.WriteLine("You have lost your salary.");
        }
        else
        {
            Console.WriteLine(salary);
        }
    }
}