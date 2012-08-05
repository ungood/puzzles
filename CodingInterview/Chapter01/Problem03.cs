using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.CodingInterview.Chapter01
{
    public static class Problem03
    {
        /// <summary>
        /// returns true if a is a permutation of b.
        /// </summary>
        public static bool IsPermutation(this string a, string b)
        {
            if(a == null)
                throw new ArgumentNullException("a");
            if(b == null)
                throw new ArgumentNullException("b");

            if (a.Length != b.Length)
                return false;

            var charsA = a.ToCharArray();
            var charsB = b.ToCharArray();

            Array.Sort(charsA);
            Array.Sort(charsB);

            for(int i = 0; i< charsA.Length; i++)
            {
                if (charsA[i] != charsB[i])
                    return false;
            }

            return true;
        }
    }

    [TestFixture]
    public class Problem03Tests
    {
        [Test]
        public void TrueTest()
        {
            Assert.IsTrue("abba".IsPermutation("baba"));
        }

        [Test]
        public void FalseTest()
        {
            Assert.IsFalse("abba".IsPermutation("abcd"));
        }
    }
}
