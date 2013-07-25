using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Physics
{
    public static class Physics
    {
        private const double K = 50000;
        public static Vector CalcForce(Puck puck, List<PointCharge> pointCharges)
        {
            Vector force = new Vector();
            for(int i = 0; i < pointCharges.Count; i++)
            {
                Vector subForce = new Vector();

                double deltaX = pointCharges[i].Center.X - puck.Center.X;
                double deltaY = pointCharges[i].Center.Y - puck.Center.Y;
                double r = Math.Sqrt(deltaX*deltaX + deltaY*deltaY);

                subForce.Direction = Math.Atan(deltaY / deltaX);
                if (deltaX > 0)
                    subForce.Direction += Math.PI;

                subForce.Magnitude = K * puck.Charge * pointCharges[i].Charge / (r * r);
                if (subForce.Magnitude < 0)
                {
                    subForce.Magnitude *= -1;
                    subForce.Direction += Math.PI;
                }
                
                force = force + subForce;
            }
            return force;
        }

        public static Vector CalcForce(PointF pt, double charge, List<PointCharge> pointCharges)
        {
            Vector force = new Vector();
            for (int i = 0; i < pointCharges.Count; i++)
            {
                Vector subForce = new Vector();

                double deltaX = pointCharges[i].Center.X - pt.X;
                double deltaY = pointCharges[i].Center.Y - pt.Y;
                double r = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                subForce.Direction = Math.Atan(deltaY / deltaX);
                if (deltaX > 0)
                    subForce.Direction += Math.PI;

                subForce.Magnitude = K * charge * pointCharges[i].Charge / (r * r);
                if (subForce.Magnitude < 0)
                {
                    subForce.Magnitude *= -1;
                    subForce.Direction += Math.PI;
                }

                force = force + subForce;
            }
            return force;
        }

        public static PointF CalcPosition(PointF loc, Vector velocity, Vector accel, double time)
        {
            PointF p = new PointF();
            p.X = (float)(loc.X + (velocity.XComponent * time + accel.XComponent * (time * time)));
            p.Y = (float)(loc.Y + (velocity.YComponent * time + accel.YComponent * (time * time)));
            return p;
        }

        public static PointF CalcPosition(PointF initLoc, Vector accel, double time)
        {
            PointF p = new PointF();
            p.X = (float)(initLoc.X + (accel.XComponent * (time * time)));
            p.Y = (float)(initLoc.Y + (accel.YComponent * (time * time)));
            return p;
        }

        public static Vector CalcVelocity(Vector initVel, Vector accel, double time)
        {
            return initVel + (accel * time);

        }
    }
}
