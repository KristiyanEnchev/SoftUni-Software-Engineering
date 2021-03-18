using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public abstract class Collection
    {
        private List<string> items;
        private int MaxSize;

        public Collection()
        {
            this.items = new List<string>();
            this.MaxSize = 100;
        }

        public int Count { get { return this.Count; } }

        public int GetMaxSize()
        {
            return MaxSize;
        }

        public List<string> GetItems()
        {
            return items;
        }
    }
}
