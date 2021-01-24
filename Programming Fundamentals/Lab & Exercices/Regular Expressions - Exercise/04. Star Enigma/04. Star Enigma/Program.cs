using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var countMessages = int.Parse(Console.ReadLine());

        var counterA = 0;
        var counterD = 0;
        var listAttackedPlanets = new List<string>();
        var listDestroyedPlanets = new List<string>();
        for (int i = 1; i <= countMessages; i++)
        {
            var encryptedMessage = Console.ReadLine();
            var patternKey = @"[starSTAR]";
            var matchKeyLetters = Regex.Matches(encryptedMessage, patternKey);
            var decryptionKey = int.Parse(matchKeyLetters.Count.ToString());
            var decryptedMessage = "";
            foreach (var encryptedSymbol in encryptedMessage)
            {
                decryptedMessage += (char)(encryptedSymbol - decryptionKey);
            }
            var pattern = @"@(?<Planet>[A-za-z]+)\d*[^@\-!:>]*:(?<Population>\d+)[^@\-!:>]*!(?<Action>[AD])![^@\-!:>]*->(?<Soldier>\d+)";
            var matchMessage = Regex.Match(decryptedMessage, pattern);

            if (matchMessage.Success)
            {
                if (matchMessage.Groups["Action"].Value == "A")
                {
                    counterA++;
                    var attackedPlanets = $"-> {matchMessage.Groups["Planet"].Value}";
                    listAttackedPlanets.Add(attackedPlanets);
                }
                else
                {
                    counterD++;
                    var destroyedPlanets = $"-> {matchMessage.Groups["Planet"].Value}";
                    listDestroyedPlanets.Add(destroyedPlanets);
                }
            }

        }
        Console.WriteLine($"Attacked planets: {counterA}");
        if (counterA != 0)
        {
            Console.WriteLine(string.Join("\n", listAttackedPlanets.OrderBy(x => x)));
        }
        Console.WriteLine($"Destroyed planets: {counterD}");
        Console.WriteLine(string.Join("\n", listDestroyedPlanets.OrderBy(x => x)));
    }
}