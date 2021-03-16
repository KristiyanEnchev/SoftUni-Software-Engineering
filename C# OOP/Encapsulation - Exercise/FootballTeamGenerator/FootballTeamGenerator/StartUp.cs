using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "END")
                {
                    break;
                }

                string[] splited = comand.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string cmd = splited[0];
                try
                {
                    if (cmd == "Add")
                    {
                        string teamName = splited[1];

                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        //endurance, sprint, dribble, passing and shooting. 

                        string playerName = splited[2];
                        int endurance = int.Parse(splited[3]);
                        int sprint = int.Parse(splited[4]);
                        int dribble = int.Parse(splited[5]);
                        int passing = int.Parse(splited[6]);
                        int shooting = int.Parse(splited[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);
                    }
                    else if (cmd == "Remove")
                    {
                        string teamName = splited[1];
                        string playerName = splited[2];

                        Team team = teams[teamName];

                        team.RemovePlayer(playerName);

                    }
                    else if (cmd == "Rating")
                    {
                        string teamname = splited[1];

                        if (!teams.ContainsKey(teamname))
                        {
                            Console.WriteLine($"Team {teamname} does not exist.");
                            continue;
                        }

                        Team team = teams[teamname];

                        Console.WriteLine($"{teamname} - {team.CalculateRating}");
                    }
                    else if (cmd == "Team")
                    {
                        string teamName = splited[1];

                        Team team = new Team(teamName);

                        teams.Add(teamName, team);
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException || ex is InvalidOperationException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
