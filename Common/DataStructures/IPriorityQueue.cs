using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.DataStructures
{
    public interface IPriorityQueue<TKey, TValue>
    {
        void Insert(TKey key, TValue value);
        TValue Peek();
        TValue PullMax();
        bool IsEmpty { get; }
    }

    public interface IPriorityQueue<T>
    {
        void Insert(T item);
        T Peek();
        T PullMax();
        bool IsEmpty { get; }
    }
}
