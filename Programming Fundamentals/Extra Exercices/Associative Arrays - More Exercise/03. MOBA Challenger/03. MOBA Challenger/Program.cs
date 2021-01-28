using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> statistic = new Dictionary<string, Dictionary<string, int>>();

            string comand = Console.ReadLine();
            while (comand != "Season end")
            {
                string[] input = comand.Split();

                if (input.Contains("->"))
                {
                    input = comand.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string player = input[0];
                    string position = input[1];
                    int power = int.Parse(input[2]);

                    if (!statistic.Keys.Contains(player))
                    {
                        statistic[player] = new Dictionary<string, int>();
                        statistic[player].Add(position, power);
                    }
                    else
                    {
                        if (!statistic[player].ContainsKey(position))
                        {
                            statistic[player].Add(position, power);
                        }
                        else
                        {
                            if (statistic[player][position] < power)
                            {
                                statistic[player][position] = power;
                            }
                        }
                    }
                }
                else if (input.Contains("vs"))
                {
                    input = comand.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string playerOne = input[0];
                    string playerTwo = input[1];
                    bool isRemoved = false;
                    if (statistic.Keys.Contains(playerOne) && statistic.Keys.Contains(playerTwo))
                    {
                        foreach (var role in statistic[playerOne])
                        {
                            foreach (var position in statistic[playerTwo])
                            {
                                if (role.Key == position.Key)
                                {
                                    if (statistic[playerOne].Values.Sum() > statistic[playerTwo].Values.Sum())
                                    {
                                        statistic.Remove(playerTwo);
                                        isRemoved = true;
                                    }
                                    else if (statistic[playerOne].Values.Sum() < statistic[playerTwo].Values.Sum())
                                    {
                                        statistic.Remove(playerOne);
                                        isRemoved = true;
                                    }
                                    break;
                                }
                            }
                            if (isRemoved)
                            {
                                break;
                            }
                        }
                    }
                }
                comand = Console.ReadLine();
            }

            statistic = statistic
                .OrderByDescending(x => x.Value.Values.Sum())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var player in statistic)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
