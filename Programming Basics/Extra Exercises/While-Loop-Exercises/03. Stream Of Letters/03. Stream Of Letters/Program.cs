using System;

namespace ConsoleApp43
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();
            int c = 0;
            int o = 0;
            int n = 0;
            string word = "";
            string finalWord = "";
            while (true)
            {
                if (comand == "End")
                {
                    break;
                }
                char simbol = char.Parse(comand);
                if (simbol >= 65 && simbol <= 90 || simbol >= 97 && simbol <= 122)
                {

                    if (simbol == 'c')
                    {
                        if (c > 0)
                        {
                            word += char.ToString(simbol);
                        }
                        c++;
                    }
                    else if (simbol == 'o')
                    {
                        if (o > 0)
                        {
                            word += char.ToString(simbol);
                        }
                        o++;
                    }
                    else if (simbol == 'n')
                    {
                        if (n > 0)
                        {
                            word += char.ToString(simbol);
                        }
                        n++;
                    }
                    else
                    {
                        word += char.ToString(simbol);
                    }
                    if (c > 0 && o > 0 & n > 0)
                    {
                        finalWord += word;
                        c = 0;
                        o = 0;
                        n = 0;
                        word = " ";
                    }
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine(finalWord);
        }
    }
}
