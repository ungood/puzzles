using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.Euler.Problem9
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        public int Solve(int sum)
        {
            for (int a = 1; a < sum; a++)
            {
                for(int b = a + 1; b < sum; b++)
                {
                    for(int c = b +1; c < sum; c++)
                    {
                        if (a + b + c == sum && a * a + b * b == c * c)
                            return a * b * c;
                    }
                }
            }

            return -1;
        }

        [Test]
        public void GivenExample()
        {
            var answer = Solve(12);//.Single();

            Assert.AreEqual(60, answer);
        }

        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var answer = Solve(1000);//.Single();
            Console.WriteLine("Problem 9: {0}", answer);
            Assert.AreEqual(31875000, answer);
        }
    }
}
