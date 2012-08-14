using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using NUnit.Framework;
using Puzzles.Euler.Problems010;

namespace Puzzles.Euler.Problems060
{
    public class Problem067
    {
        public static int FindMaxPath(string filename)
        {
            var assembly = typeof(Problem067).Assembly;
            foreach(var name in assembly.GetManifestResourceNames())
            {
                Console.WriteLine(name);
            }
            
            using(var stream = assembly.GetManifestResourceStream(filename))
            using(var reader = new StreamReader(stream))
            {
                var list = new List<IList<int>>();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(line.Split(' ').Select(int.Parse).ToList());
                }

                return Problem018.FindMaxPath(list);
            }
        }
    }

    public class Problem067Tests
    {
        [Test]
        public void Solution()
        {
            var answer = Problem067.FindMaxPath("Puzzles.Euler.Problems060.Problem067.txt");
            Console.WriteLine("Problem 067: {0}", answer);
            Assert.AreEqual(7273, answer);
        }
    }
}
