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
    }
}
