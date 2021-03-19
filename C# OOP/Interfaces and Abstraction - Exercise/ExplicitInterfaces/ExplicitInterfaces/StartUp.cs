using System;
using System.Text;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "End")
                {
                    break;
                }

                string[] peopleData = comand.Split();
                string name = peopleData[0];
                string country = peopleData[1];
                int age = int.Parse(peopleData[2]);

                var citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                sb.AppendLine(person.GetName());
                sb.AppendLine(resident.GetName());
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
