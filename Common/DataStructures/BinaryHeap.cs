using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.DataStructures
{
    public class BinaryHeap<TValue> : IPriorityQueue<TValue>
    {
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private TValue[] array;
        private IComparer<TValue> comparer;

        public BinaryHeap(IComparer<TValue> comparer = null, int capacity = 1)
        {
            this.comparer = comparer ?? Comparer<TValue>.Default;
            array = new TValue[capacity];
            Capacity = capacity;
            Count = 0;
        }


        public void Insert(TValue value)
        {
            if(Count >= Capacity)
                DoubleCapacity();

            var index = Count;
            Count++;

            array[index] = value;

            while(index != 0)
            {
                var parent = index / 2;
                if (Compare(parent, index) > 0)
                    break;

                Swap(parent, index);
                index = parent;
            }
        }

        public TValue Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap contains no elements.");
            return array[0];
        }

        public TValue PullMax()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap contains no elements.");

            // Swap last element with the root, remove the root.
            var value = array[0];
            array[0] = default(TValue);
            Swap(0, Count - 1);
            Count--;

            Heapify(0);
            
            return value;
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        private void DoubleCapacity()
        {
            Capacity = Capacity * 2;
            Array.Resize(ref array, Capacity);
        }

        private int Compare(int a, int b)
        {
            return comparer.Compare(array[a].Key, array[b].Key);
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        
        private void Heapify(int index)
        {
            var left = index * 2 + 1;
            var right = index * 2 + 2;
            var largest = index;

            if (left < Count && Compare(left, largest) > 0)
                largest = left;
            
            if (right < Count && Compare(right, largest) > 0)
                largest = right;

            if(largest != index)
            {
                Swap(index, largest);
                Heapify(largest);
            }
        }
    }
}
