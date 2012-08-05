using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.DataStructures;

namespace Puzzles.CodingInterview.Chapter03
{
    public class SetOfStacks<T> : IStack<T>
    {
        public int MaxStack { get; private set; }

        private readonly Common.DataStructures.LinkedList<ArrayStack<T>> stacks
            = new Common.DataStructures.LinkedList<ArrayStack<T>>(); 
        
        public SetOfStacks(int maxStack)
        {
            MaxStack = maxStack;
        }

        public void Push(T item)
        {
            if(stacks.IsEmpty)
                stacks.AddLast(new ArrayStack<T>(MaxStack));

            var stack = stacks.Last.Item;
            if (stack.IsFull)
                stack = stacks.AddLast(new ArrayStack<T>(MaxStack)).Item;

            stack.Push(item);
        }

        public T Pop()
        {
            if(stacks.IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            var stack = stacks.Last.Item;
            var item = stack.Pop();
            if (stack.IsEmpty)
                stacks.RemoveLast();
            return item;
        }

        public T Peek()
        {
            if (stacks.IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            var stack = stacks.Last.Item;
            return stack.Peek();
        }

        public bool IsEmpty
        {
            get { return stacks.IsEmpty; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stacks.SelectMany(stack => stack).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    [TestFixture]
    public class Problem03Tests
    {
        [Test]
        public void SimpleTest()
        {
            var stacks = new SetOfStacks<int>(3);

            Assert.IsTrue(stacks.IsEmpty);

            stacks.Push(1);
            stacks.Push(2);
            stacks.Push(3);
            stacks.Push(4);
            stacks.Push(5);
            stacks.Push(6);
            stacks.Push(7);

            Assert.IsFalse(stacks.IsEmpty);

            Assert.AreEqual(7, stacks.Pop());
            Assert.AreEqual(6, stacks.Pop());
            Assert.AreEqual(5, stacks.Pop());
            Assert.AreEqual(4, stacks.Pop());
            Assert.AreEqual(3, stacks.Pop());
            Assert.AreEqual(2, stacks.Pop());
            Assert.AreEqual(1, stacks.Pop());

            Assert.IsTrue(stacks.IsEmpty);
        }
    }
}
