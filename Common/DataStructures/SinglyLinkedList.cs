using System;
using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class SinglyLinkedList<T> : IEnumerable<T>, IStack<T>
    {
        public class Node
        {
            public T Item { get; internal set; }
            public Node Next { get; internal set; }
            
            public Node(T item, Node next)
            {
                Item = item;
                Next = next;
            }
        }
        
        public Node First { get; private set; }

        public SinglyLinkedList()
        {
            First = null;
        }

        public Node AddFirst(T item)
        {
            var newNode = new Node(item, First);
            First = newNode;
            return newNode;
        }

        public Node RemoveFirst()
        {
            if (First == null)
                throw new InvalidOperationException("Sequence contains no elements.");

            var node = First;
            First = First.Next;
            node.Next = null;
            return node;
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

        #region Implementation of IStack<T>

        public void Push(T item)
        {
            AddFirst(item);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return RemoveFirst().Item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return First.Item;
        }

        public bool IsEmpty
        {
            get { return First == null; }
        }

        #endregion
    }
}
