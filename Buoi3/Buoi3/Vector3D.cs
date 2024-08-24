using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    public class Vector3D : Vector
    {
        private float x;
        private float y;
        private float z;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public Vector3D(float x = 0f, float y = 0f, float z = 0f)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D(Vector3D vt3)
        {
            X = vt3.x;
            Y = vt3.y;
            Z = vt3.z;
        }

        public override string GetInfo()
        {
            return $"({x,-3}, {y,-3}, {z})";
        }
        public override void ShowInfo()
        {
            Console.Write(GetInfo());
        }
        public static bool IsVector3D(Vector vt)
        {
            return vt is Vector3D;
        }
        public override Vector Sum(Vector vt)
        {
            Vector3D vt3 = vt as Vector3D;
            return new Vector3D((float)Math.Round(X + vt3.X, 1), (float)Math.Round(Y + vt3.Y, 1), (float)Math.Round(Z + vt3.Z, 1));
        }

        public override bool Orth(Vector vt)
        {
            Vector3D vt3 = vt as Vector3D;
            return X * vt3.X + Y * vt3.Y + Z * vt3.Z == 0f;
        }
    }
}
