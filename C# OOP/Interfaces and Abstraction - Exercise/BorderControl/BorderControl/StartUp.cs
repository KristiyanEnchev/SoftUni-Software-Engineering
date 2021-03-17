using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<IIndentifiable> identifible = new List<IIndentifiable>();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "End")
                {
                    break;
                }

                string[] splited = comand.Split();

                if (splited.Length == 3)
                {
                    string name = splited[0];
                    int age = int.Parse(splited[1]);
                    string id = splited[2];

                    identifible.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = splited[0];
                    string id = splited[1];

                    identifible.Add(new Robot(id, model));
                }
            }

            string filter = Console.ReadLine();

            List<IIndentifiable> filtered = identifible.Where(i => i.Id.EndsWith(filter)).ToList();

            foreach (var identifiabl in filtered)
            {
                Console.WriteLine(identifiabl.Id);
            }

        }
    }
}
