using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputItems = Console.ReadLine().Split();

            var addCollection = new AddCollection();
            var removeCollection = new AddRemoveCollection();
            var myList = new MyList();

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();

            foreach (var item in inputItems)
            {
                //addCollection.AddCollections(item);
                sb1.Append(addCollection.AddCollections(item)).Append(" ");

                //removeCollection.AddCollections(item);
                sb2.Append(removeCollection.AddCollections(item)).Append(" ");

                //myList.AddCollections(item);
                sb3.Append(myList.AddCollections(item)).Append(" ");
            }

            int n = int.Parse(Console.ReadLine());

            StringBuilder sb4 = new StringBuilder();
            StringBuilder sb5 = new StringBuilder();

            while (n > 0)
            {
                //removeCollection.Remove();
                sb4.Append(removeCollection.Remove()).Append(" ");

                //myList.Remove();
                sb5.Append(myList.Remove()).Append(" ");

                n--;
            }

            Console.WriteLine(sb1.ToString().TrimEnd());
            Console.WriteLine(sb2.ToString().TrimEnd());
            Console.WriteLine(sb3.ToString().TrimEnd());
            Console.WriteLine(sb4.ToString().TrimEnd());
            Console.WriteLine(sb5.ToString().TrimEnd());

        }
    }
}
