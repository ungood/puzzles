using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.Spatial;
using Puzzles.Euler.RiskyMoon.Lattice;
using Puzzles.Euler.RiskyMoon.Risk;

namespace Puzzles.Euler.RiskyMoon.Tests
{
    [TestFixture]
    public class RiskCalculatorTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            return new[]
            {
                new TestCaseData(new AStarRiskCalculator())
            };
        } 

        [Test]
        [TestCaseSource("GetImplementations")]
        public void UnitCircleTest(IRiskCalculator calculator)
        {
            var unitCircle = new []
            {
                new CartesianCoordinates(0, 0, 1),
                new CartesianCoordinates(0, 1, 0),
                new CartesianCoordinates(1, 0, 0),
                new CartesianCoordinates(0, 0, -1),
                new CartesianCoordinates(0, -1, 0),
                new CartesianCoordinates(-1, 0, 0)
            };

            var stations = unitCircle.Select(coord => new Station(coord));

            var actual = calculator.CalculateRisk(stations, 1).TotalRisk;

            Assert.AreEqual(0.5, actual);
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void GivenExampleTest(IRiskCalculator riskCalculator)
        {
            var calculator = new ParallelNaiveSphereLatticeCalculator();
            var stations = calculator.FindLatticePoints(7).Select(x => new Station(x));
            var actual = riskCalculator.CalculateRisk(stations, 7).TotalRisk;

            Assert.AreEqual(0.1784943998, Math.Round(actual, 10));
        }

        [Test]
        [Ignore("Slow")]
        public void MaxZ()
        {
            var latticeCalculator = new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator());
            var riskCalculator = new AStarRiskCalculator();

            var results = Enumerable.Range(1, 50).AsParallel()
                .Select(radius =>
                {
                    var stations = latticeCalculator.FindLatticePoints(radius).Select(coord => new Station(coord));
                    return riskCalculator.CalculateRisk(stations, radius);
                })
                .OrderBy(result => result.Radius);
                

            foreach (var result in results)
            {
                var maxZ = result.Path.Max(path => path.Source.CartesianLocation.Z - path.Target.CartesianLocation.Z);
                Console.WriteLine("{0}: {1}", result.Radius, maxZ);
            }
        }

        /// <summary>
        /// Interesting to note that a moon with radius 2n has the same minimal risk as a moon with radius n.
        /// M(2r) = M(r)
        /// </summary>
        // 0.06924307373552: 27
        // 0.07394084651690: 21
        // 0.10140133687823: 25
        // 0.10296540470811: 19
        // 0.10599928132709: 23
        // 0.10714794796212: 15, 30
        // 0.12091813090701: 29
        // 0.12169805976751: 9, 18
        // 0.13403020289275: 17
        // 0.16087118102414: 11, 22
        // 0.17849439975514: 28, 7, 14
        // 0.18175660153131: 26, 13
        // 0.18414647913495: 10, 20, 5
        // 0.23604566644613: 3, 24, 6, 12
        // 0.50000000000000: 2, 16, 8, 4, 1
        [Test]
        [Ignore("Slow")]
        public void FirstFiftyGroupedByRisk()
        {
            var latticeCalculator = new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator());
            var riskCalculator = new AStarRiskCalculator();

            var groups = Enumerable.Range(1, 50).AsParallel()
                .Select(radius =>
                {
                    var stations = latticeCalculator.FindLatticePoints(radius).Select(coord => new Station(coord));
                    return riskCalculator.CalculateRisk(stations, radius);
                })
                .GroupBy(result => result.TotalRisk)
                .OrderBy(grp => grp.Key);

            foreach(var grp in groups)
            {
                Console.Write("{0}, {1}:", grp.Key, grp.First().TotalDistanceRatio);
                foreach(var value in grp.OrderBy(result => result.Radius))
                {
                    Console.Write(" {0:N0}", value.Radius);
                }
                Console.WriteLine();
            }
        }

        
        [Test]
        public void FindSolutions()
        {
            Console.WriteLine(FindResult(15));
            Console.WriteLine("--");

            Console.WriteLine(FindResult(30));
            Console.WriteLine("--");
            Console.WriteLine(FindResult(3));
            Console.WriteLine("--");

            Console.WriteLine(FindResult(10));
            Console.WriteLine("--");

        }


        private RiskResult FindResult(int radius)
        {
            var latticeCalculator = new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator());
            var riskCalculator = new AStarRiskCalculator();

            var stations = latticeCalculator.FindLatticePoints(radius).Select(coord => new Station(coord));
            return riskCalculator.CalculateRisk(stations, radius);
        }
    }
}
