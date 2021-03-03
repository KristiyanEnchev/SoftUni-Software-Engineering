using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public ListyIterator(params T[] items)
        {
            this.items = items.ToList();
        }

        public bool Move()
        {
            bool hasNext = this.HasNext();

            if (this.HasNext())
            {
                this.index++;
            }

            return hasNext;
        }

        public void Print()
        {

            if (this.index >= this.items.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);

        }

        public bool HasNext()
        {
            return this.index < this.items.Count - 1;
        }

        //public List<T> PrintAll()
        //{
        //    foreach (var item in items)
        //    {
        //        Console.WriteLine(string.Join());
        //    }
        //}

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
