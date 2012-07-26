using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static void AssertSequenceEquals<T>(this IEnumerable<T> actual, params T[] expected)
        {
            CollectionAssert.AreEqual(expected, actual);
        }

        public static void AssertSequenceEquivalentTo<T>(this IEnumerable<T> actual, params T[] expected)
        {
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
