using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DataStructures
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>(); 

        public void Enqueue(T item)
        {
            linkedList.AddFirst(item);
        }

        public T Dequeue()
        {
            if(linkedList.IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return linkedList.RemoveLast();
        }

        public T Peek()
        {
            if (linkedList.IsEmpty)
                throw new InvalidOperationException("Queue is empty.");

            return linkedList.Last.Item;
        }

        public bool IsEmpty
        {
            get { return linkedList.IsEmpty; }
        }
    }
}
