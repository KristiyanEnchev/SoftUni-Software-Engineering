using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : Collection, IRemoveble
    {
        public AddRemoveCollection()
            : base()
        {
        }

        public int AddCollections(string item)
        {
            GetItems().Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string item = GetItems()[GetItems().Count - 1];

            GetItems().Remove(item);

            return item;
        }
    }
}
