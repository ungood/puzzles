using System;
using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class BinaryHeap<TKey, TValue> : BinaryHeap<KeyValuePair<TKey, TValue>>, IPriorityQueue<TKey, TValue> 
    {
        public BinaryHeap(IComparer<TKey> comparer = null,
            int capacity = DynamicArray<TValue>.DefaultCapacity)
            : base(new KeyValuePairComparer<TKey, TValue>(comparer), capacity)
        {
        }

        public void Insert(TKey key, TValue value)
        {
            Insert(new KeyValuePair<TKey, TValue>(key, value));
        }

        public new TValue Peek()
        {
            return base.Peek().Value;
        }

        public new TValue PullMax()
        {
            return base.PullMax().Value;
        }
    }

    public class BinaryHeap<T> : IPriorityQueue<T>
    {
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private readonly DynamicArray<T> array; 
        private readonly IComparer<T> comparer;

        public BinaryHeap(IComparer<T> comparer = null,
            int capacity = DynamicArray<T>.DefaultCapacity)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            array = new DynamicArray<T>(capacity);
            Count = 0;
        }
        
        public void Insert(T value)
        {
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

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap contains no elements.");
            return array[0];
        }

        public T PullMax()
        {
            if (Count == 0)
                throw new InvalidOperationException("Heap contains no elements.");

            // Swap last element with the root, remove the root.
            var value = array[0];
            array[0] = default(T);
            Swap(0, Count - 1);
            Count--;

            Heapify(0);
            
            return value;
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        private int Compare(int a, int b)
        {
            return comparer.Compare(array[a], array[b]);
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
