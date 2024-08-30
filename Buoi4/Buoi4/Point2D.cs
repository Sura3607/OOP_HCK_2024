using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public class Point2D : IPoint, ICloneable
    {
        private float x, y;

        public float X { get => x;private set => x = value; }
        public float Y { get => y;private set => y = value; }
        public Point2D(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }
        public object Clone()
        {
            return new Point2D(this.x, this.y);
        }
        public string GetPoint()
        {
            return $"({this.x,-4},{this.y,4})";
        }
        public float cal_dist(IPoint point)
        {
            Point2D point2D = point as Point2D;
            return (float)Math.Round(Math.Sqrt((point2D.X - X) * (point2D.X - X) 
                                             + (point2D.Y - Y) * (point2D.Y - Y)),2);
        }
        
        public static Point2D operator +(Point2D a, Point2D b) => new Point2D(a.X + b.X, a.Y + b.Y);
        public static Point2D operator -(Point2D a, Point2D b) => new Point2D(a.X - b.X, a.Y - b.Y);
    }
}
