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

        public float cal_area()
        {
            throw new NotImplementedException();
        }
    }
}
