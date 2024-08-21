using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vector
{
    float x;
    float y;
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public Vector(float _X = 0, float _Y = 0)
    {
        X = _X;
        Y = _Y;
    }
    public Vector(Vector v)
    {
        X = v.X;
        Y = v.Y;
    }
    public string Show()
    {
        return $"({x}; {y})";        
    }
    public void printVector()
    {
        Console.WriteLine(Show());
    }
    public Vector Add(Vector v)
    {
        return new Vector(x + v.X , y + v.Y);
    }
    public Vector Sub(Vector v)
    {
        return new Vector(x - v.X , y - v.Y);
    }
    public float Mul(Vector v)
    {
        return x*v.X + y*v.Y;
    }
    public bool Onth(Vector v)
    {
        return Mul(v) == 0;
    }
}