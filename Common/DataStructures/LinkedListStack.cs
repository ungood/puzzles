using System;
using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>(); 

        public void Push(T item)
        {
            linkedList.AddFirst(item);
        }

        public T Pop()
        {
            if (linkedList.IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return linkedList.RemoveFirst();
        }

        public T Peek()
        {
            if (linkedList.IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return linkedList.First.Item;
        }

        public bool IsEmpty
        {
            get { return linkedList.IsEmpty; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}