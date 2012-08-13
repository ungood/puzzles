using System;
using System.Collections.Generic;
using NUnit.Framework;
using Puzzles.Common.DataStructures;

namespace Puzzles.Common.Test.DataStructures
{
    [TestFixture]
    public class SetTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            return new[]
            {
                new TestCaseData(new BucketSet<string>()),
            };
        } 

        [Test]
        [TestCaseSource("GetImplementations")]
        public void CanAddItemsToAnEmptySet(Common.DataStructures.ISet<string> set)
        {
            Assert.IsTrue(set.Add("apple"));
            Assert.IsFalse(set.Add("apple"));

            Assert.IsTrue(set.Contains("apple"));
            Assert.IsFalse(set.Contains("banana"));
        }
    }
}
