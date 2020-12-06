using System;
class Program
{
    static void Main(string[] args)
    {
        double N1 = double.Parse(Console.ReadLine());
        double N2 = double.Parse(Console.ReadLine());
        string operation = Console.ReadLine();
        double result = 0;
        string type = "";
        if (operation == "+")
        {
            result = N1 + N2;
            if (result % 2 == 0)
            {
                type = "even";
            }
            else
            {
                type = "odd";
            }
            Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
        }
        else if (operation == "-")
        {
            result = N1 - N2;
            if (result % 2 == 0)
            {
                type = "even";
            }
            else
            {
                type = "odd";
            }
            Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
        }
        else if (operation == "*")
        {
            result = N1 * N2;
            if (result % 2 == 0)
            {
                type = "even";
            }
            else
            {
                type = "odd";
            }
            Console.WriteLine($"{N1} {operation} {N2} = {result} - {type}");
        }
        else if (operation == "/")
        {
            if (N1 == 0)
            {
                Console.WriteLine($"Cannot divide {N2} by zero");
            }
            else if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else if (N1 != 0 && N2 != 0)
            {
                result = N1 / N2;
                Console.WriteLine($"{N1} {operation} {N2} = {result:f2}");
            }
        }
        else if (operation == "%")
        {
            if (N1 == 0)
            {
                Console.WriteLine($"Cannot divide {N2} by zero");
            }
            else if (N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }
            else
            {
                result = N1 % N2;
                Console.WriteLine($"{N1} {operation} {N2} = {result}");
            }
        }
    }
}
