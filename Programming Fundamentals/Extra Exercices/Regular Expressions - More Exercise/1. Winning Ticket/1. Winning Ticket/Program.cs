using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] winningSymbols = new string[] { "@", "#", "$", @"\^" };

            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                bool noMatch = false;

                for (int b = 0; b < winningSymbols.Length; b++)
                {
                    string currentPattern = $@"[{winningSymbols[b]}]+";

                    string leftSideOfTicket = tickets[i].Substring(0, 10);
                    string rightSideOfTicket = tickets[i].Substring(10, 10);

                    int counterLeft = 0;
                    int counterRight = 0;


                    foreach (Match match in Regex.Matches(leftSideOfTicket, currentPattern))
                    {
                        counterLeft = match.Value.Length;
                    }
                    foreach (Match match in Regex.Matches(rightSideOfTicket, currentPattern))
                    {
                        counterRight = match.Value.Length;
                    }

                    if (counterLeft >= 6 && counterRight >= 6 && (counterLeft + counterRight) < 20)
                    {

                        if (winningSymbols[b] == @"\^")
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "^");
                        }
                        else
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "" + winningSymbols[b]);
                        }
                        noMatch = true;
                        break;
                    }
                    else if ((counterLeft + counterRight) == 20)
                    {
                        if (winningSymbols[b] == @"\^")
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "^ Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine("ticket \"" + tickets[i] + "\" - " + Math.Min(counterLeft, counterRight) + "" + winningSymbols[b] + " Jackpot!");
                        }
                        noMatch = true;
                        break;
                    }
                    else
                    {
                        noMatch = false;

                    }
                }

                if (noMatch == false)
                {
                    Console.WriteLine("ticket \"" + tickets[i] + "\" - no match");
                }
            }
        }
    }
}