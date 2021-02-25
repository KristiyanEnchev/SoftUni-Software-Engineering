using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class NodeMusic<T>
    {
        public NodeMusic(T src)
        {
            Value = src;
        }

        public T Value { get; set; }

        public NodeMusic<T> Next { get; set; }

        public NodeMusic<T> Previous { get; set; }
    }
}