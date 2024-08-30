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

            List<ICricle> cricles = CreateCricles(points);
            ShowList(cricles);
            Show_area(cricles);

            Console.WriteLine("\n----------------------------------------\n");
            ShowALL_RelativePosition(points, cricles);

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
        public static List<ICricle> CreateCricles(List<IPoint> listPoint)
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
                    Console.WriteLine($"Point {i + 1} {list[i].Point_Info()}");

            Console.WriteLine();

            Console.WriteLine("Point3D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Point3D))
                    Console.WriteLine($"Point {i + 1} {list[i].Point_Info()}");
            Console.WriteLine("\n-----------------------------------------------\n");
        }
        public static void ShowList(List<ICricle> list)
        {
            Console.WriteLine("\n-----------------------------------------------\n");
            Console.WriteLine("Cricle2D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Cricle2D))
                    Console.WriteLine($"Cricle {i + 1} : Point {list[i].GetPoint().Point_Info()} and r = {list[i].GetR()}");

            Console.WriteLine();

            Console.WriteLine("Cricle3D:");
            for (int i = 0; i < list.Count; i++)
                if (list[i].GetType() == typeof(Cricle3D))
                    Console.WriteLine($"Cricle {i + 1} : Point {list[i].GetPoint().Point_Info()} and r = {list[i].GetR()}");
            Console.WriteLine("\n-----------------------------------------------\n");
        }
        //showlist khoang cach
        public static void Show_dist(List<IPoint> points)
        {
            for (int i = 0;i < points.Count; i++)           
                for(int j = i + 1; j < points.Count; j++)                
                    if (points[i].GetType() == points[j].GetType())
                        Console.WriteLine($"Khoan cach giua Point {i + 1} va Point {j + 1} la: {points[i].cal_dist(points[j])}");                            
        }
        //showlist dien tich
        public static void Show_area(List<ICricle> cricles)
        {
            for(int i = 0; i< cricles.Count; i++)
            {
                if (cricles[i].GetType() == typeof(Cricle2D))               
                    Console.WriteLine($"Hinh tron Cricle {i + 1} co dien tich la: {cricles[i].cal_area()}");               
                else
                    Console.WriteLine($"Hinh cau Cricle {i + 1} co dien tich la: {cricles[i].cal_area()}");
            }
        }

        //tinh khoang cach tuong doi voi duong tron/hinh cau
        public static int GetRelativePosition(IPoint point, ICricle cricle)
        {
            if (point.cal_dist(cricle.GetPoint()) > cricle.GetR()) return 1;
            else if (point.cal_dist(cricle.GetPoint()) < cricle.GetR()) return -1; 
            else return 0;
        }
        public static void ShowALL_RelativePosition(List<IPoint> points, List<ICricle> cricles)
        {
            for(int i = 0;i < cricles.Count;i++)
            {
                if (cricles[i].GetType() == typeof(Cricle2D))
                    Console.WriteLine($"Hinh tron Cricle {i + 1}: r = {cricles[i].GetR()}");
                else
                    Console.WriteLine($"Hinh cau Cricle {i + 1}: r = {cricles[i].GetR()}");
                for (int j = 0; j < points.Count; j++)
                {
                    if (cricles[i].GetPoint().GetType() != points[j].GetType() || i == j)
                        continue;
                    int k = GetRelativePosition(points[j], cricles[i]);
                    if (k > 0)
                        Console.WriteLine($"\tPoint {j + 1} nam ngoai (khoang cach voi tam la: {points[j].cal_dist(cricles[i].GetPoint())})");
                    else if (k < 0)
                        Console.WriteLine($"\tPoint {j + 1} nam trong (khoang cach voi tam la: {points[j].cal_dist(cricles[i].GetPoint())})");
                    else
                        Console.WriteLine($"\tPoint {j + 1} nam tren (khoang cach voi tam la: {points[j].cal_dist(cricles[i].GetPoint())})");
                }
                Console.WriteLine();
            }
        }
    }
}
