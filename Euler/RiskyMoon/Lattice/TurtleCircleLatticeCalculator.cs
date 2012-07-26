using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Lattice
{
    /// <summary>
    /// Calculates the lattice points on a circle by tracing around it (like a Turtle)
    /// </summary>
    public class TurtleCircleLatticeCalculator : ICircleLatticeCalculator
    {
        public IEnumerable<CartesianCoordinates> FindLatticePoints(int radius, int z)
        {
            

            var rSquared = (long)radius * radius;

            var list = new List<CartesianCoordinates>();

            var circleRadius = (int)Math.Sqrt(rSquared - ((long)z * z));
            var startingPoint = circleRadius;
            var x = circleRadius;
            var y = 0;

            do
            {
                var point = new CartesianCoordinates(x, y, z);
                var magSquared = point.MagnitudeSquared;
                if(magSquared == rSquared)
                {
                    list.Add(new CartesianCoordinates(x, y, z));
                }

                MoveAntiClockwise(ref x, ref y, magSquared > rSquared);
            } while(x != startingPoint || y != 0);

            return list;
        }

        private void MoveAntiClockwise(ref int x, ref int y, bool outsideCircle)
        {
            int quadrant;
            if(y >= 0)
            {
                quadrant = x >= 0 ? 1 : 2;
            }
            else
            {
                quadrant = x >= 0 ? 4 : 3;
            }

            if(outsideCircle)
            {
                switch(quadrant)
                {
                    case 1:
                        x--;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x++;
                        break;
                    case 4:
                        y++;
                        break;
                }
            }
            else
            {
                switch(quadrant)
                {
                    case 1:
                        y++;
                        break;
                    case 2:
                        x--;
                        break;
                    case 3:
                        y--;
                        break;
                    case 4:
                        x++;
                        break;
                }
            }
        }
    }
}
