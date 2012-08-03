using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.DataStructures
{
    public interface IPriorityQueue<TValue>
    {
        void Insert(TKey priority, TValue item);
        TValue Peek();
        TValue PullMax();
        bool IsEmpty { get; }
    }
}
