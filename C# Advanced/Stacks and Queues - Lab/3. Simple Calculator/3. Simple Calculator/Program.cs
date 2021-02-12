using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentence = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(sentence.Reverse());

            while (stack.Count > 1)
            {
                int leftNum = int.Parse(stack.Pop());
                string operatorSign = stack.Pop(); 
                int rightNum = int.Parse(stack.Pop());

                if (operatorSign == "+")
                {
                    stack.Push((leftNum + rightNum).ToString());
                }
                else if (operatorSign == "-")
                {
                    stack.Push((leftNum - rightNum).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
