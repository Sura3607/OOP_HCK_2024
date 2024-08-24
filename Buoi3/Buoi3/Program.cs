using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bai1();
            Bai2();

            Console.ReadKey();
        }
        static void Bai1()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("01", 2.7f, "Le Thi Thu", "Ha Noi", new DateTime(2005, 06, 05)));
            students.Add(new Student("02", 3.6f, "Nguyen Thi Minh", "Ha Noi", new DateTime(2005, 02, 12)));
            students.Add(new Student("03", 2.9f, "Tran Van Khoa", "Da Nang", new DateTime(2005, 03, 23)));
            students.Add(new Student("04", 3.2f, "Pham Thi Hoa", "Gia Lai", new DateTime(2005, 04, 18)));
            students.Add(new Student("05", 3.8f, "Hoang Van Long", "Ho Chi Minh", new DateTime(2005, 05, 30)));

            Console.WriteLine("Bang ban dau");
            Student.ShowList(students);
      
            Console.WriteLine("\nBang sau khi sap xep");
            students = Student.Reverse(Student.SortStudents(students));
            Student.ShowList(students);
        }
        static void Bai2(int n = 10)
        {
            List<Vector> vectors = new List<Vector>();
            Random rand = new Random();

            //them vào 2 cặp vector trực giao
            n = n - 4;
            vectors.Add(new Vector2D(1, 1));
            vectors.Add(new Vector2D(-1, 1));
            vectors.Add(new Vector3D(1, 0, 2));
            vectors.Add(new Vector3D(2, 15.3f, -1));

            for (int i = 0; i < n; i++)
            {
                int rd = rand.Next(11);
                float randomX = (float)Math.Round(rand.NextDouble() * n, 1);
                float randomY = (float)Math.Round(rand.NextDouble() * n, 1);
                if (rd % 2 == 0)
                    vectors.Add(new Vector2D(randomX, randomY));
                else
                {
                    float randomZ = (float)Math.Round(rand.NextDouble() * n, 1);
                    vectors.Add(new Vector3D(randomX, randomY, randomZ));
                }
            }
            //show list
            Console.WriteLine("Vector2D:");
            for (int i = 0;i < vectors.Count;i++)
            {
                if (Vector2D.IsVector2D(vectors[i]))
                {
                    Console.Write($"Vector {i + 1,-3} = ");
                    vectors[i].ShowInfo();
                    Console.WriteLine();
                }     
            }
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("Vector3D:");
            for (int i = 0; i < vectors.Count; i++)
            {
                if (Vector3D.IsVector3D(vectors[i]))
                {
                    Console.Write($"Vector {i + 1,-3} = ");
                    vectors[i].ShowInfo();
                    Console.WriteLine();
                }                                
            }

            //Sum list
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("CONG CAC PHN TU TRONG LIST:");
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = i+1; j < vectors.Count; j++)
                {
                    if (vectors[i].GetType() == vectors[j].GetType())
                    {
                        Console.Write($"Vector {i + 1,-3} + Vector {j + 1,-3} = ");
                        vectors[i].Sum(vectors[j]).ShowInfo();

                        if (Vector2D.IsVector2D(vectors[i]))
                            Console.Write("\t(Vector2D)");
                        else
                            Console.Write("\t(Vector3D)");

                        Console.WriteLine();
                    }
                }
            }

            //check orth
            Console.WriteLine("\n------------------------------\n");
            Console.WriteLine("KIEM TRA CAC Vector TRUC GIAO VOI NHAU:");
            for (int i = 0; i < vectors.Count; i++)
            {
                for (int j = i + 1; j < vectors.Count; j++)
                {
                    if (!(vectors[i].GetType() == vectors[j].GetType()))
                        continue;
                    if (!vectors[i].Orth(vectors[j]))
                        continue;

                    Console.Write($"Vector{i + 1}{vectors[i].GetInfo()} va Vector{j + 1}{vectors[i].GetInfo()} ");

                    if (Vector2D.IsVector2D(vectors[i]))
                        Console.Write("la cap Vector2D truc giao");
                    else
                        Console.Write("la cap Vector3D truc giao");

                    Console.WriteLine();
                }
            }
        }
    }
}
