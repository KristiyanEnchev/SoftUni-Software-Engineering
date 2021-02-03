using System;
using System.Linq;

namespace More_Exercice_Text_procesing
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string text = Console.ReadLine();
                string theName = string.Empty;
                string theAge = string.Empty;

                string[] name = text.Split("@", StringSplitOptions.RemoveEmptyEntries);
                if (name.Length > 1)
                {
                    string[] name1 = name[1].Split("|", StringSplitOptions.RemoveEmptyEntries);
                    theName = name1[0];
                }
                else
                {
                    string[] name1 = name[0].Split("|", StringSplitOptions.RemoveEmptyEntries);
                    theName = name1[0];
                }
                string[] age = text.Split("#", StringSplitOptions.RemoveEmptyEntries);
                if (age.Length > 1)
                {
                    string[] age1 = age[1].Split("*", StringSplitOptions.RemoveEmptyEntries);
                    theAge = age1[0];
                }
                else
                {
                    string[] age1 = age[0].Split("*", StringSplitOptions.RemoveEmptyEntries);
                    theAge = age1[0];
                }

                Console.WriteLine($"{theName} is {theAge} years old.");
            }
        }
    }
}
