using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "End")
                {
                    break;
                }

                string[] splited = comand.Split();

                if (splited[0] == "Citizen")
                {
                    string name = splited[1];
                    int age = int.Parse(splited[2]);
                    string id = splited[3];
                    string birthdate = splited[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (splited[0] == "Robot")
                {
                    string model = splited[1];
                    string id = splited[2];
                }
                else if (splited[0] == "Pet")
                {
                    string name = splited[1];
                    string birthdate = splited[2];

                    birthables.Add(new Pet(name, birthdate));
                }
            }

            string filter = Console.ReadLine();

            List<IBirthable> filtered = birthables.Where(i => i.Birthdate.EndsWith(filter)).ToList();

            foreach (var birthable in filtered)
            {
                Console.WriteLine(birthable.Birthdate);
            }

        }
    }
}
