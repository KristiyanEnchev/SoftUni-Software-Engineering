using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MyStack<int> mystack = new MyStack<int>();

            string comandInput = Console.ReadLine();

            while (comandInput != "END")
            {
                string[] comandData = comandInput.Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
                string comand = comandData[0];

                if (comand == "Push")
                {
                    for (int i = 1; i < comandData.Length; i++)
                    {
                        int item = int.Parse(comandData[i]);
                        mystack.Push(item);
                    }
                }
                else if (comand == "Pop")
                {
                    try
                    {
                        mystack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                comandInput = Console.ReadLine();
            }

            foreach (var item in mystack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine, mystack));
        }
    }
}
