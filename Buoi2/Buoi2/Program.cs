using OOP_HCK_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{    
    static void Main(string[] args)
    {        
        Bai1();
        //Bai2();

        Console.ReadKey();
    }
    static void Bai1()
    {
        Student[] students = new Student[10]
        {
            new Student("Nguyen Van Nam", 3.8f),
            new Student("Tran Thi Mai", 3.5f),
            new Student("Le Hong Phong", 4.0f),
            new Student("Pham Ngoc Anh", 3.2f),
            new Student("Đao Minh Quan", 3.9f),
            new Student("Mai Ha Nam", 4.2f),
            new Student("Do Hoang Quan", 4.1f),
            new Student("Bach Đang Giang", 3.7f),
            new Student("Truong Hoang Sa", 3.6f),
            new Student("Le Van Sang", 3.4f)
        };
        
        Student st = new Student();
        st.ShowListStudent(students);

        Console.WriteLine("-------------------------------------------------------");

        students = st.SortStudents(students);
        st.ShowListStudent(students);
        
    }
    static void Bai2()
    {
        List<Vector> vectors = new List<Vector>
        {
            new Vector(1.2f, 0.0f),   // Vector 1
            new Vector(4.0f, 1.5f),   // Vector 2 (Othn Vector 5)
            new Vector(2.5f, -3.0f),  // Vector 3
            new Vector(3.0f, 2.5f),   // Vector 4 (Othn Vector 3)
            new Vector(-1.5f, 4.0f),  // Vector 5        
            new Vector(3.7f, 0.8f),   // Vector 6
            new Vector(-0.8f, 3.7f),  // Vector 7 (Othn Vector 6)
            new Vector(1.0f, -2.0f),  // Vector 8
            new Vector(0.0f, 1.2f),   // Vector 9 (Othn Vector 1)
            new Vector(2.0f, 1.0f)    // Vector 10 (Othn Vector 8)
        };
        Console.WriteLine($"Vector1 + Vector2 = {vectors[0].Add(vectors[1]).Show()}");
        Console.WriteLine($"Vector1 - Vector2 = {vectors[0].Sub(vectors[1]).Show()}");
        Console.WriteLine($"Vector1 * Vector2 = {vectors[0].Mul(vectors[1])}");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Cac cap vector truc giao la:");
        for (int i = 0; i < vectors.Count; i++)
        {
            for (int j = i+1; j < vectors.Count; j++)
            {
                if (vectors[i].Onth(vectors[j]))
                    Console.WriteLine($"{vectors[i].Show()}\tand\t{vectors[j].Show()}");
            }
        }
        Stack<Vector> st = new Stack<Vector>();
        Vector[] arr = st.ToArray();
        
    }
}