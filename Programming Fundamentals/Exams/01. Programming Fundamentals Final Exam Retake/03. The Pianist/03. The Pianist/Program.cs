using System;
using System.Linq;
using System.Collections.Generic;

namespace New_Exam_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> composition = new Dictionary<string, List<string>>();

            int pieceCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pieceCount; i++)
            {
                string[] input = Console.ReadLine().Split("|");
                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                composition.Add(piece, new List<string>());
                composition[piece].Add(composer);
                composition[piece].Add(key);
            }

            string comand = Console.ReadLine();
            while (comand != "Stop")
            {
                string[] input = comand.Split("|");
                string cmd = input[0];
                string nameOfPiece = input[1];

                if (cmd == "Add")
                {
                    if (composition.ContainsKey(nameOfPiece))
                    {
                        Console.WriteLine($"{nameOfPiece} is already in the collection!");
                    }
                    else
                    {
                        string composer = input[2];
                        string key = input[3];
                        composition.Add(nameOfPiece, new List<string>());
                        composition[nameOfPiece].Add(composer);
                        composition[nameOfPiece].Add(key);

                        Console.WriteLine($"{nameOfPiece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (cmd == "Remove")
                {

                    if (composition.ContainsKey(nameOfPiece))
                    {
                        composition.Remove(nameOfPiece);
                        Console.WriteLine($"Successfully removed {nameOfPiece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {nameOfPiece} does not exist in the collection.");
                    }
                }
                else if (cmd == "ChangeKey")
                {
                    if (composition.ContainsKey(nameOfPiece))
                    {
                        string newKey = input[2];
                        composition[nameOfPiece].RemoveAt(1);
                        composition[nameOfPiece].Insert(1, newKey);
                        Console.WriteLine($"Changed the key of {nameOfPiece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {nameOfPiece} does not exist in the collection.");
                    }
                }

                comand = Console.ReadLine();
            }

            foreach (var item in composition.OrderBy(x => x.Key).ThenBy(x => x.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
