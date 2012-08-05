using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.DataStructures;

namespace Puzzles.Common.Test.DataStructures
{
    [TestFixture]
    public class StackTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            return new[]
            {
                new TestCaseData(new LinkedListStack<int>()),
                new TestCaseData(new ArrayStack<int>(50)), 
            };
        }
            
        [Test]
        [TestCaseSource("GetImplementations")]
        public void NewStackIsEmpty(IStack<int> stack)
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void PushPopShouldReturnSameElement(IStack<int> stack)
        {
            stack.Push(10);
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(10, stack.Peek());
            Assert.AreEqual(10, stack.Pop());
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void PoppingEmptyStackShouldThrow(IStack<int> stack)
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void StackShouldReverseAList(IStack<int> stack)
        {
            foreach(var i in Enumerable.Range(1, 5))
                stack.Push(i);

            var reversed = new List<int>();
            while(!stack.IsEmpty)
                reversed.Add(stack.Pop());

            reversed.AssertSequenceEquals(5, 4, 3, 2, 1);
        }
    }
}
