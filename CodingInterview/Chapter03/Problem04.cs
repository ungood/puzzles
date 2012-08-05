using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.DataStructures;
using Puzzles.Common.Test;

namespace Puzzles.CodingInterview.Chapter03
{
    public class TowerOfHanoiStack : IEnumerable<int>
    {
        private readonly ArrayStack<int> stack;

        public string Name { get; private set; }
        public int Height { get; private set; }

        public TowerOfHanoiStack(string name, int height)
        {
            Name = name;
            Height = height;
            stack = new ArrayStack<int>(height);
        }

        public void Fill()
        {
            for(int i = Height; i >= 1; i--)
                stack.Push(i);
        }

        public static void MoveOne(TowerOfHanoiStack from, TowerOfHanoiStack to)
        {
            if(!to.stack.IsEmpty && to.stack.Peek() < from.stack.Peek())
                throw new InvalidOperationException("Cannot move a larger disk on top of a smaller disk.");

            var disk = from.stack.Pop();
            to.stack.Push(disk);

            Console.WriteLine("{0} ({1}) -> {2}", from.Name, disk, to.Name);
        }

        public static void MoveAll(int n, TowerOfHanoiStack from, TowerOfHanoiStack to, TowerOfHanoiStack buffer)
        {
            if(n == 0)
                return;

            MoveAll(n - 1, from, buffer, to);
            MoveOne(from, to);
            MoveAll(n - 1, buffer, to, from);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class Problem04
    {
        public static Tuple<TowerOfHanoiStack, TowerOfHanoiStack, TowerOfHanoiStack> Solve(int height)
        {
            var a = new TowerOfHanoiStack("A", height);
            var b = new TowerOfHanoiStack("B", height);
            var c = new TowerOfHanoiStack("C", height);
            a.Fill();

            TowerOfHanoiStack.MoveAll(height, a, c, b);

            return new Tuple<TowerOfHanoiStack, TowerOfHanoiStack, TowerOfHanoiStack>(a, b, c);
        }
    }

    [TestFixture]
    public class Problem04Tests
    {
        [Test]
        public void MoveOneTest()
        {
            var a = new TowerOfHanoiStack("A", 1);
            var b = new TowerOfHanoiStack("B", 1);
            a.Fill();

            TowerOfHanoiStack.MoveOne(a, b);

            a.AssertSequenceEquals();
            b.AssertSequenceEquals(1);
        }

        [Test]
        public void MoveOneFails()
        {
            var a = new TowerOfHanoiStack("A", 3);
            var b = new TowerOfHanoiStack("B", 3);
            a.Fill();

            TowerOfHanoiStack.MoveOne(a, b);
            Assert.Throws<InvalidOperationException>(() => TowerOfHanoiStack.MoveOne(a, b));
        }

        [Test]
        public void SolveTest([Range(1, 7)] int height)
        {
            var solution = Problem04.Solve(height);
            var a = solution.Item1;
            var b = solution.Item2;
            var c = solution.Item3;

            a.AssertSequenceEquals();
            b.AssertSequenceEquals();
            var expected = Enumerable.Range(1, height).Reverse();
            c.AssertSequenceEquals(expected.ToArray());
        }
    }
}
