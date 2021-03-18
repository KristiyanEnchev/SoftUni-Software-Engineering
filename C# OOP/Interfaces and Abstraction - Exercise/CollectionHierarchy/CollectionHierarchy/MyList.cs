using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : Collection, IMyList
    {
        public int AddCollections(string item)
        {
            GetItems().Insert(0, item);
            return 0;
        }

        public int GetUsed()
        {
            return this.GetItems().Count;
        }

        public string Remove()
        {
            string item = GetItems()[0];
            GetItems().RemoveAt(0);

            return item;
        }
    }
}
