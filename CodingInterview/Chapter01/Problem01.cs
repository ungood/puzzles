using System;
using NUnit.Framework;

namespace Puzzles.CodingInterview.Chapter01
{
    public static class Problem01
    {
        /// <summary>
        /// Assumptions for sake of simplicity:
        /// ASCII 8-bit strings
        /// </summary>
        public static bool HasAnyDuplicateCharacters(this string input)
        {
            if(input == null)
                throw new ArgumentNullException("input");

            if (input.Length == 0)
                return false;

            var chars = input.ToCharArray();
            Array.Sort(chars);
            var prev = chars[0];

            for(int i = 1; i < chars.Length; i++)
            {
                if (chars[i] == prev)
                    return true;
                prev = chars[i];
            }
            
            return false;
        }
    }

    [TestFixture]
    public class Problem01Tests
    {
        [Test]
        public void NullStringShouldThrow()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => s.HasAnyDuplicateCharacters());
        }
        
        [Test]
        public void EmptyStringShouldReturnFalse()
        {
            Assert.IsFalse("".HasAnyDuplicateCharacters());
        }

        [Test]
        public void StringWithDuplicatesShouldReturnTrue()
        {
            Assert.IsTrue("abcdefgha".HasAnyDuplicateCharacters());
        }

        [Test]
        public void StringWithoutDuplicatesShouldReturnFalse()
        {
            Assert.IsFalse("abcdefgh".HasAnyDuplicateCharacters());
        }
    }
}
