using System;
using NUnit.Framework;

namespace Puzzles.CodingInterview.Chapter01
{
    public static class Problem02
    {
        public static string Reverse(this string input)
        {
            if(input == null)
                throw new ArgumentNullException("input");

            var chars = input.ToCharArray();

            var first = 0;
            var last = chars.Length - 1;
            while(first < last)
            {
                var temp = chars[first];
                chars[first] = chars[last];
                chars[last] = temp;

                first++;
                last--;
            }

            return new string(chars);
        }
    }

    [TestFixture]
    public class Problem02Tests
    {
        [Test]
        public void SimpleTest()
        {
            Assert.AreEqual("dlrow olleh", "hello world".Reverse());
        }
    }
}
