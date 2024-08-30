using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IPoint> points = CreatePoints();
            ShowList(points);
            Show_dist(points);

            List<ICricle> cricles = CreateCricles_FromPoints(points);
            ShowList(cricles);

            Console.ReadKey();
        }
        public static List<IPoint> CreatePoints(int n = 5)
        {
            var list = new List<IPoint>();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                int rd = rand.Next(11);
                float randomX = (float)Math.Round(rand.NextDouble() * n, 1);
                float randomY = (float)Math.Round(rand.NextDouble() * n, 1);
                if (rd % 2 == 0)
                    list.Add(new Point2D(randomX, randomY));
                else
                {
                    float randomZ = (float)Math.Round(rand.NextDouble() * n, 1);
                    list.Add(new Point3D(randomX, randomY, randomZ));
                }
            }
            return list;
        }
        //2 cách tạo list cricle
        public static List<ICricle> CreateCricles(int n = 5)
        {
            var list = new List<ICricle>();
            List<IPoint> listPoint = CreatePoints(n);
            Random rand = new Random();
            for(int i = 0;i < n; i++)
            {
                int rd = rand.Next(11);
                float randomR = (float)Math.Round(rand.NextDouble() * n, 1);
                if (listPoint[i].GetType() == typeof(Point2D))
                    list.Add(new Cricle2D((Point2D)listPoint[i], randomR));
                else
                    list.Add(new Cricle3D((Point3D)listPoint[i], randomR));
            }
            return list;
        }
        public static List<ICricle> CreateCricles_FromPoints(List<IPoint> listPoint)
        {
            var list = new List<ICricle>();
            Random rand = new Random();
            for (int i = 0; i < listPoint.Count; i++)
            {
                int rd = rand.Next(11);
                float randomR = (float)Math.Round(rand.NextDouble() * listPoint.Count, 1);
                if (listPoint[i].GetType() == typeof(Point2D))
                    list.Add(new Cricle2D((Point2D)listPoint[i], randomR));
                else
                    list.Add(new Cricle3D((Point3D)listPoint[i], randomR));
            }
            return list;
        }
        public static void ShowList(List<IPoint> list)
        {
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("Point2D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Point2D))
                    Console.WriteLine($"Point {i + 1} {list[i].GetPoint()}");

            Console.WriteLine();

            Console.WriteLine("Point3D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Point3D))
                    Console.WriteLine($"Point {i + 1} {list[i].GetPoint()}");
            Console.WriteLine("\n-----------------------------------------------\n");
        }
        public static void ShowList(List<ICricle> list)
        {
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("Cricle2D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Cricle2D))
                    Console.WriteLine($"Cricle {i + 1} : Point {list[i].GetPoint()} and r = {list[i].GetR()}");

            Console.WriteLine();

            Console.WriteLine("Cricle3D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Cricle3D))
                    Console.WriteLine($"Cricle {i + 1} : Point {list[i].GetPoint()} and r = {list[i].GetR()}");
            Console.WriteLine("\n-----------------------------------------------\n");
        }
        public static void Show_dist(List<IPoint> points)
        {
            for (int i = 0;i < points.Count; i++)           
                for(int j = i + 1; j < points.Count; j++)                
                    if (points[i].GetType() == points[j].GetType())
                        Console.WriteLine($"Khoan cach giua Point {i + 1} va Point {j + 1} la: {points[i].cal_dist(points[j])}");                            
        }
    }
}
