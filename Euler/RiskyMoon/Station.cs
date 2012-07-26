using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon
{
    public class Station : IEquatable<Station>
    {
        public CartesianCoordinates CartesianLocation { get; private set; }

        public LatLongRadians RadianLocation { get; private set; }

        public Station(CartesianCoordinates cartesian)
        {
            CartesianLocation = cartesian;
            RadianLocation = (LatLongRadians)cartesian;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", CartesianLocation, RadianLocation);
        }

        public double CalculateRisk(Station destination)
        {
            var distance = MathEx.GreatCircleDistance(RadianLocation, destination.RadianLocation);
            var x = distance / (RadianLocation.Radius * Math.PI);
            return x * x;
        }

        #region Equality

        public bool Equals(Station other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return other.CartesianLocation.Equals(CartesianLocation);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != typeof(Station))
            {
                return false;
            }
            return Equals((Station)obj);
        }

        public override int GetHashCode()
        {
            return CartesianLocation.GetHashCode();
        }

        public static bool operator ==(Station left, Station right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Station left, Station right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
