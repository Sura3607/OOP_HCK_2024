using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    public class Student : Human
    {
        private string id;
        private float gpa;
        public string Id { get => id; set => id = value; }
        public float Gpa { get => gpa; set => gpa = value; }
        public Student(string id = "00", float gpa = 0, string name = "None", string place_of_birth = "UnKnow", DateTime birthday = default) : base(name, place_of_birth, birthday)
        {
            this.id = id;
            this.gpa = gpa;
        }
        public Student(Student student) : base(student)
        {
            this.id = student.Id;
            this.gpa = student.Gpa;
        }
        public string GetInfo()
        {
            return $"{id,-5}|{Name,-20}|{gpa,6}|{Place_of_birth,-20}|{Birthday.ToString("dd/MM/yyyy")}";
        }
        public static void ShowList(List<Student> students)
        {
            Console.WriteLine($"{"STT",-5}|{"Id",-5}|{"Name",-20}|{"Gpa",6}|{"Place_of_birth",-20}|{"Birthday"}");
            Console.WriteLine("------------------------------------------------------------------------");
            for (int i = 0; i<students.Count; i++)
            {
                Console.Write($"{i + 1,-5}|");
                Console.WriteLine(students[i].GetInfo());
            }
        }
        public static List<Student> SortStudents(List<Student> students)
        {
            for (int i = 1; i < students.Count; ++i)
            {
                Student key = students[i];
                int j = i - 1;

                while (j >= 0 && students[j].Gpa > key.Gpa)
                {
                    students[j + 1] = students[j];
                    j = j - 1;
                }
                students[j + 1] = key;
            }
            return students;
        }
        public static List<Student> Reverse(List<Student> students)
        {
            int start = 0;
            int end = students.Count - 1;
            while (start < end)
            {
                Student temp = students[start];
                students[start++] = students[end];
                students[end--] = temp;
            }
            return students;
        }
    }
}
