using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public class Cricle2D : ICricle, ICloneable
    {
        private Point2D point;
        private float r;
        private const float pi = 3.1415926535897931f;

        public Point2D Point { get => point;private set => point = value; }
        public float R { get => r;private set => r = value; }
        public Cricle2D(Point2D point = default, float r = 0)
        {
            this.point = point;
            this.r = r;
        }
        public object Clone()
        {
            return new Cricle2D(this.point, this.r);
        }
        public IPoint GetPoint()
        {
            return this.point;
        }
        public float GetR()
        {
            return this.r;
        }
        public float cal_area()
        {
            return (float)Math.Round(pi * this.r * this.r, 2);
        }
    }
}
