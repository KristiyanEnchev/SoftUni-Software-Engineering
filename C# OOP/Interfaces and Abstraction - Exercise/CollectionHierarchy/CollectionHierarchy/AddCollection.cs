using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : Collection, IAddCollection
    {
        private int index = 0;

        public AddCollection()
            : base()
        {
        }

        public int AddCollections(string item)
        {
            this.GetItems().Add(item);

            return index++;
        }
    }
}