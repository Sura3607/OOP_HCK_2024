using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public class Cricle3D : ICricle, ICloneable
    {
        private Point3D point;
        private float r;
        private const float pi = 3.1415926535897931f;

        public Point3D Point { get => point;private set => point = value; }
        public float R { get => r;private set => r = value; }
        public Cricle3D(Point3D point = default, float r = 0)
        {
            this.point = point;
            this.r = r;
        }
        public object Clone()
        {
            return new Cricle3D(this.point, this.r);
        }
        public string GetPoint()
        {
            return $"({this.Point.X, -4}, {this.Point.Y, -4}, {this.Point.Z,3})";
        }
        public float GetR()
        {
            return this.r;
        }
        public float cal_area()
        {
            return (float)Math.Round(4 * pi * this.r * this.r, 2);
        }
    }
}
