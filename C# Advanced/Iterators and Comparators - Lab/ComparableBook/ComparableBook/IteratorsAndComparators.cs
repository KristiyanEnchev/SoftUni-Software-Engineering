using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class IteratorsAndComparators<T> : IEnumerator<T>
    {
        private List<T> books;
        private int currentIndex = -1;

        public IteratorsAndComparators(List<T> books)
        {
            this.books = books;
        }

        public T Current => books[currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            currentIndex ++;

            return currentIndex < books.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}