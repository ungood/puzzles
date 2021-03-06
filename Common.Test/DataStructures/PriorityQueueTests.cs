﻿using System;
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
        public void SimpleTest()
        {
            var pq = new BinaryHeap<int>();

            pq.Insert(11);
            pq.Insert(5);
            pq.Insert(3);
            pq.Insert(4);
            pq.Insert(8);
            pq.Insert(15);

            var list = new List<int>();
            while(!pq.IsEmpty)
                list.Add(pq.PullMax());

            list.AssertSequenceEquals(15, 11, 8, 5, 4, 3);
        }
    }
}
