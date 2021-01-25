using System;
using System.Linq;

namespace Text_processing_Exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pass = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var password in pass)
            {
                if (password.Length >= 3 && password.Length <= 16)
                {
                    if (password.All(x => char.IsLetterOrDigit(x)) || password.Contains("-") || password.Contains("_"))
                    {
                        Console.WriteLine(password);
                    }
                }
            }
        }
    }
}
