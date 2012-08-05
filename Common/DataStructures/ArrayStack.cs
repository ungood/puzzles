using System;
using System.Collections;
using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly T[] array;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ArrayStack(int capacity)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException("capacity");

            array = new T[capacity];
            Capacity = capacity;
            Count = 0;
        }

        public void Push(T item)
        {
            if (Count == array.Length)
                throw new InvalidOperationException("Stack is full!");

            array[Count++] = item;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            return array[--Count];
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty!");

            return array[Count-1];
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public bool IsFull
        {
            get { return Count == Capacity; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
