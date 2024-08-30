using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    public class Vector2D : Vector
    {
        private float x;
        private float y;
        public float X { get => x; private set => x = value; }
        public float Y { get => y; private set => y = value; }
        public Vector2D(float x = 0f, float y = 0f)
        {
            X = x;
            Y = y;
        }
        public Vector2D(Vector2D vt2)
        {
            X = vt2.X;
            Y = vt2.Y;
        }
        public override string GetInfo()
        {
            return $"({X,-3}, {Y})";
        }
        public override void ShowInfo()
        {
            Console.Write(GetInfo());
        }
        public static bool IsVector2D(Vector vt)
        {
            return vt is Vector2D;
        }
        public override Vector Sum(Vector vt)
        {
            Vector2D vt2 = vt as Vector2D;
            return new Vector2D((float)Math.Round(X + vt2.X,1), (float)Math.Round(Y + vt2.Y, 1));
        }        
        public override bool Orth(Vector vt)
        {
            Vector2D vt2 = vt as Vector2D;
            return X * vt2.X + Y * vt2.Y == 0;
        }

        public override Vector Sub(Vector vt)
        {
            Vector2D vt2 = vt as Vector2D;
            return new Vector2D((float)Math.Round(X - vt2.X, 1), (float)Math.Round(Y - vt2.Y, 1));
        }
    }
}
