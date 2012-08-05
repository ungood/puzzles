using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DataStructures
{
    public class DynamicArray<T>
    {
        public const int DefaultCapacity = 32;

        private T[] array;

        public int Capacity { get; private set; }
        
        public DynamicArray(int capacity = DefaultCapacity)
        {
            if(capacity <= 0)
                throw new ArgumentOutOfRangeException("capacity", "capacity must be positive.");

            Capacity = capacity;
            array = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if(index >= Capacity)
                    throw new IndexOutOfRangeException("Index out of bounds.");

                return array[index];
            }
            set
            {
                if(index >= Capacity)
                    DoubleCapacity();

                array[index] = value;
            }
        }

        private void DoubleCapacity()
        {
            Capacity = Capacity * 2;
            Array.Resize(ref array, Capacity);
        }
    }
}
