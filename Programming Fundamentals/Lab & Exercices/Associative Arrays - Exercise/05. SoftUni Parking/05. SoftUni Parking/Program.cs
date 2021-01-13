using System;
using System.Collections.Generic;
namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> dic = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                string task = cmd[0];
                string user = cmd[1];

                if (task == "register")
                {
                    string licencePlate = cmd[2];
                    if (!dic.ContainsKey(user))
                    {
                        dic.Add(user, licencePlate);
                        Console.WriteLine($"{user} registered {licencePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licencePlate}");
                    }
                }
                else if (task == "unregister")
                {
                    if (!dic.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        dic.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
