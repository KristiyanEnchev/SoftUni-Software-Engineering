using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> openBrackets = new Stack<int>();
            bool balancedBrackets = true;

            for (int i = 0; i < input.Length; i++)
            {
                char tempChar = input[i];
                int tempInt = 0;

                switch (tempChar)
                {
                    case '{': tempInt = 1; break;
                    case '}': tempInt = -1; break;
                    case '(': tempInt = 2; break;
                    case ')': tempInt = -2; break;
                    case '[': tempInt = 3; break;
                    case ']': tempInt = -3; break;

                    default: break;
                }

                if (tempInt > 0)
                {
                    openBrackets.Push(tempInt);
                    continue;
                }

                if (openBrackets.Count == 0)
                {
                    balancedBrackets = false;
                    break;
                }

                if (tempInt > 0)
                {
                    openBrackets.Push(tempInt);
                    continue;
                }
                else
                {
                    int tempStackPeek = openBrackets.Peek();

                    if ((tempStackPeek + tempInt) == 0)
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        balancedBrackets = false;
                        break;
                    }
                }
            }

            if (balancedBrackets)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
