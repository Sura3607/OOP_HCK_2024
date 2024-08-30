using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public class Point3D : IPoint, ICloneable
    {
        private float x, y, z;

        public float X { get => x;private set => x = value; }
        public float Y { get => y;private set => y = value; }
        public float Z { get => z;private set => z = value; }
        public Point3D(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public object Clone()
        {
            return new Point3D(this.x, this.y, this.z);
        }
        public string Point_Info()
        {
            return $"({this.x,-4}, {this.y,-4}, {this.z,3})";
        }
        public float cal_dist(IPoint point)
        {
            Point3D point2D = point as Point3D;
            return (float)Math.Round(Math.Sqrt((point2D.X - X) * (point2D.X - X) 
                                             + (point2D.Y - Y) * (point2D.Y - Y) 
                                             + (point2D.Z - Z) * (point2D.Z - Z)),2);
        }
        public static Point3D operator +(Point3D a, Point3D b) => new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Point3D operator -(Point3D a, Point3D b) => new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
}
