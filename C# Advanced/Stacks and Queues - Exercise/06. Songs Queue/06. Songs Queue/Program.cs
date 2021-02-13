using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputSongs = Console.ReadLine().Split(", ").ToList();
            var songsQueue = new Queue<string>();

            foreach (var song in inputSongs)
            {
                songsQueue.Enqueue(song);
            }

            while (songsQueue.Any())
            {
                var command = Console.ReadLine();

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command.StartsWith("Add"))
                {
                    var songFullname = command.Substring(4);
                    if (songsQueue.Contains(songFullname))
                    {
                        Console.WriteLine($"{songFullname} is already contained! ");
                    }
                    else
                    {
                        songsQueue.Enqueue(songFullname);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine("{0}", string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}