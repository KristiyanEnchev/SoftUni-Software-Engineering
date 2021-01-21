using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamCount; i++)
            {
                string[] newTeam = Console.ReadLine().Split("-");
                string creatorName = newTeam[0];
                string teamName = newTeam[1];

                Team team = new Team(teamName, creatorName);

                bool isTeamNameExisting = teams.Select(x => x.TeamName).Contains(teamName);
                bool isCreatorNameExisting = teams.Select(x => x.CreatorName).Contains(creatorName);

                if (!isTeamNameExisting)
                {
                    if (!isCreatorNameExisting)
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string teamMembers = Console.ReadLine();
            while (teamMembers != "end of assignment")
            {
                string[] comandArg = teamMembers.Split(new char[] { '-', '>' }).ToArray();
                string newUser = comandArg[0];
                string teamName = comandArg[2];

                bool isTeamExisting = teams.Select(x => x.TeamName).Contains(teamName);

                bool isCreatorExisting = teams.Select(x => x.CreatorName).Contains(newUser);
                bool isTeamMemberExisting = teams.Select(x => x.Members).Any(x => x.Contains(newUser));

                if (!isTeamExisting)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (isCreatorExisting || isTeamMemberExisting)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamName);
                    teams[index].Members.Add(newUser);
                }

                teamMembers = Console.ReadLine();
            }

            Team[] teamsToDisband = teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0).ToArray();

            Team[] fullTeam = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).Where(x => x.Members.Count > 0).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (Team team in fullTeam)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.CreatorName}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine($"Teams to disband:");
            foreach (Team item in teamsToDisband)
            {
                sb.AppendLine(item.TeamName);
            }
            Console.WriteLine(sb.ToString());
        }
    }

    class Team
    {
        public Team(string teamName, string creatorName)
        {
            TeamName = teamName;
            CreatorName = creatorName;
            Members = new List<string>();
        }
        public string TeamName { get; set; }
        public string CreatorName { get; set; }
        public List<string> Members { get; set; }
    }
}
