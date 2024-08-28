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

        public float cal_area()
        {
            throw new NotImplementedException();
        }
    }
}
