using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Lattice
{
    class RecursiveCubesSphereLatticeCalculator : ISphereLatticeCalculator
    {
        private class Cube
        {
            public int MinX { get; private set; }
            public int MaxX { get; private set; }
            public int MinY { get; private set; }
            public int MaxY { get; private set; }
            public int MinZ { get; private set; }
            public int MaxZ { get; private set; }

            public Cube(int radius)
            {
                MinX = MinY = MinZ = (radius * -1);
                MaxX = MaxY = MaxZ = radius;
            }

            public Cube(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
            {
                MinX = minX;
                MinY = minY;
                MinZ = minZ;
                MaxX = maxX;
                MaxY = maxY;
                MaxZ = maxZ;
            }

            /// <summary>
            ///    /--------/X,Y,Z
            ///   /        /|
            ///  /        / |
            /// /--------/  |
            /// |        |  /
            /// |dX,y,dZ | /
            /// |        |/
            /// +--------/
            /// x,y,z
            /// </summary>
            public Cube[] Split()
            {
                var dX = MinX + ((MaxX - MinX) / 2);
                var dY = MinY + ((MaxY - MinY) / 2);
                var dZ = MinZ + ((MaxZ - MinZ) / 2);

                return new Cube[]
                {
                    new Cube(MinX, MinY, MinZ,   dX,   dY,   dZ),
                    new Cube(dX+1, MinY, MinZ, MaxX,   dY,   dZ),  
                    new Cube(MinX, dY+1, MinZ,   dY, MaxY,   dZ), 
                    new Cube(MinX, MinY, dZ+1,   dX,   dY, MaxZ), 
                    new Cube(MinX, dY+1, dZ+1,   dX, MaxY, MaxZ), 
                    new Cube(dX+1, MinY, dZ+1, MaxX,   dY, MaxZ),
                    new Cube(dX+1, dY+1, MinZ, MaxX, MaxY,   dZ), 
                    new Cube(dX+1, dY+1, dZ+1, MaxX, MaxY, MaxZ) 
                };
            }

            public CartesianCoordinates[] GetCorners()
            {
                return new []
                {
                    new CartesianCoordinates(MinX, MinY, MinZ),
                    new CartesianCoordinates(MinX, MinY, MaxZ),
                    new CartesianCoordinates(MinX, MaxY, MinZ),
                    new CartesianCoordinates(MinX, MaxY, MaxZ),
                    new CartesianCoordinates(MaxX, MinY, MinZ),
                    new CartesianCoordinates(MaxX, MinY, MaxZ),
                    new CartesianCoordinates(MaxX, MaxY, MinZ),
                    new CartesianCoordinates(MaxX, MaxY, MaxZ),
                };
            }

            public bool IsValid
            {
                get { return (MaxX > MinX) && (MaxY > MinY) && (MaxZ > MinZ); }
            }

            public override string ToString()
            {
                return string.Format("({0}, {1}, {2}), ({3}, {4}, {5})", MinX, MinY, MinZ, MaxX, MaxY, MaxZ);
            }
        }

        public IEnumerable<CartesianCoordinates> FindLatticePoints(int radius)
        {
            return Recurse(radius * radius, new Cube(radius)).Distinct();
        }

        private IEnumerable<CartesianCoordinates> Recurse(long rSquared, Cube cube)
        {
            //Console.WriteLine(cube);
            if (!cube.IsValid)
                return Enumerable.Empty<CartesianCoordinates>();

            var corners = cube.GetCorners().Select(corner => new Tuple<CartesianCoordinates, long>(corner, corner.MagnitudeSquared)).ToArray();

            if(corners.All(corner => corner.Item2 < rSquared))
                return Enumerable.Empty<CartesianCoordinates>();

            var list = corners.Where(c => c.Item2 == rSquared).Select(corner => corner.Item1)
                .ToList();

            var children = cube.Split();
            foreach(var child in children)
            {
                list.AddRange(Recurse(rSquared, child));
            }

            return list;
        }
    }
}
