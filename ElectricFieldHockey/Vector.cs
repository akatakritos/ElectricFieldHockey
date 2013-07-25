using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricFieldHockey
{
    public struct Vector
    {
        private double mDirection;

        public double Direction
        {
            get { return mDirection; }
            set { mDirection = value; }
        }
        private double mMagnitude;

        public double Magnitude
        {
            get { return mMagnitude; }
            set
            {
                mMagnitude = value;
            }
        }

        public Vector(double dir, double mag)
        {
            mDirection = dir;
            mMagnitude = mag;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v = new Vector();
            double x = v1.Magnitude * Math.Cos(v1.Direction) + v2.Magnitude * Math.Cos(v2.Direction);
            double y = v1.Magnitude * Math.Sin(v1.Direction) + v2.Magnitude * Math.Sin(v2.Direction);
            v.Direction = Math.Atan(y / x);
            if (x<0)
                v.Direction += Math.PI;
            v.Magnitude = Math.Sqrt(x * x + y * y);
            return v;
        }

        public static Vector operator *(Vector v, double scalar)
        {
            Vector v1 = new Vector();
            v1.Magnitude = v.Magnitude * scalar;
            v1.Direction = v.Direction;
            return v1;
        }

        public double XComponent
        {
            get { return Magnitude * Math.Cos(Direction); }
        }

        public double YComponent
        {
            get { return Magnitude * Math.Sin(Direction); }
        }
    }
}
