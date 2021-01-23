using System;
using System.Collections.Generic;
using System.Linq;

namespace Object_and_Classes
{
    class Songs
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }


        static void Main(string[] args)
        {
            int songscCount = int.Parse(Console.ReadLine());
            List<Songs> songs = new List<Songs>();

            for (int i = 0; i < songscCount; i++)
            {
                string[] information = Console.ReadLine()
                    .Split("_", StringSplitOptions.RemoveEmptyEntries);

                string type = information[0];
                string name = information[1];
                string time = information[2];

                Songs song = new Songs();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Songs song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Songs song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}