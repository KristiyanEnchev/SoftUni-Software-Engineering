using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type[] allTypes = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in allTypes)
            {

                MethodInfo[] methoods = type.GetMethods();

                foreach (var method in methoods)
                {
                    if (!method.GetCustomAttributes().Any(a => a.GetType() == typeof(AuthorAttribute)))
                    {
                        continue;
                    }

                    Attribute[] atributes = method.GetCustomAttributes().ToArray();

                    foreach (var attr in atributes)
                    {
                        if (attr is AuthorAttribute)
                        {
                            Console.WriteLine($"{type.Name} is written by {((AuthorAttribute)attr).Name}");
                        }
                    }
                }

                if (!type.GetCustomAttributes().Any(a => a.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }

                Attribute[] attributes = type.GetCustomAttributes()
                    .Where(t => t.GetType() == typeof(AuthorAttribute))
                    .Select(a => (AuthorAttribute)a)
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    Console.WriteLine($"{type.Name} is written by {((AuthorAttribute)attribute).Name}");
                }
            }
        }
    }
}
