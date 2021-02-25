using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class MusicLinkedList<T>
    {
        private int count = 0;

        public NodeMusic<T> Head { get; set; }

        public NodeMusic<T> Tail { get; set; }

        public void ForeachFromTail(Action<NodeMusic<T>> action)
        {
            NodeMusic<T> currentNodeMusic = Tail;
            while (currentNodeMusic != null)
            {
                action(currentNodeMusic);
                currentNodeMusic = currentNodeMusic.Previous;
            }
        }

        public void ForeachFromHead(Action<NodeMusic<T>> action)
        {
            NodeMusic<T> currentNodeMusic = Head;
            while (currentNodeMusic != null)
            {
                action(currentNodeMusic);
                currentNodeMusic = currentNodeMusic.Next;
            }
        }

        public void AddHead(NodeMusic<T> NodeMusic)
        {
            count++;
            if (Head == null)
            {
                Head = NodeMusic;
                Tail = NodeMusic;
                return;
            }

            NodeMusic.Next = Head;
            Head.Previous = NodeMusic;
            Head = NodeMusic;
        }

        public void AddLast(NodeMusic<T> NodeMusic)
        {
            count++;
            if (Tail == null)
            {
                Head = NodeMusic;
                Tail = NodeMusic;
                return;
            }

            NodeMusic.Previous = Tail;
            Tail.Next = NodeMusic;
            Tail = NodeMusic;
        }

        public NodeMusic<T> RemoveHead()
        {
            if (Head == null)
            {
                return null;
            }

            count--;

            var NodeMusicToReturn = Head;
            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return NodeMusicToReturn;
        }

        public NodeMusic<T> RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }

            count--;
            var NodeMusicToReturn = Tail;
            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }

            return NodeMusicToReturn;
        }
    }
}