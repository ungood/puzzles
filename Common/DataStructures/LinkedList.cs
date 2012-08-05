using System;
using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public T Item { get; internal set; }
            public Node Next { get; internal set; }
            public Node Prev { get; internal set; }
            
            internal Node(Node prev, T item, Node next)
            {
                Item = item;
                Next = next;
                Prev = prev;
            }
        }
        
        public Node First { get; private set; }
        public Node Last { get; private set; }

        public LinkedList()
        {
            First = Last = null;
        }

        public Node AddFirst(T item)
        {
            var newNode = new Node(null, item, First);

            if(IsEmpty)
                Last = newNode;
            else
                First.Prev = newNode;

            First = newNode;
            return newNode;
        }

        public Node AddLast(T item)
        {
            var newNode = new Node(Last, item, null);

            if (IsEmpty)
                First = newNode;
            else
                Last.Next = newNode;

            Last = newNode;
            return newNode;
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Sequence contains no elements.");

            return Remove(First);
        }

        public T RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Sequence contains no elements.");

            return Remove(Last);
        }

        private T Remove(Node node)
        {
            if(node.Next != null)
                node.Next.Prev = node.Prev;

            if(node.Prev != null)
                node.Prev.Next = node.Next;

            if(First == node)
                First = node.Next;
            if (Last == node)
                Last = node.Prev;

            node.Next = node.Prev = null;

            return node.Item;
        }

        public bool IsEmpty
        {
            get { return First == null; }
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            var node = First;
            while(node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
