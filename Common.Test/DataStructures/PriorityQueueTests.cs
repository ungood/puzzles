using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.DataStructures;

namespace Puzzles.Common.Test.DataStructures
{
    [TestFixture]
    class PriorityQueueTests
    {
        [Test]
        public void SimpleTst()
        {
            var pq = new BinaryHeap<int, int>();

            pq.Insert(11, 11);
            pq.Insert(5, 5);
            pq.Insert(3, 3);
            pq.Insert(4, 4);
            pq.Insert(8, 8);
            pq.Insert(15, 15);

            var list = new List<int>();
            while(!pq.IsEmpty)
                list.Add(pq.PullMax());

            list.AssertSequenceEquals(15, 11, 8, 5, 4, 3);
        }
    }
}
