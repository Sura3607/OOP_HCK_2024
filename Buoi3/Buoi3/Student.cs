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
        public Student(string id, float gpa, string name, string place_of_birth, DateTime birthday) : base(name, place_of_birth, birthday)
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
            return $"{id,-5} {Name,-10} {gpa,6} {Place_of_birth,-20} {Birthday}";
        }
        public static void ShowList(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
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
        }
    }
}
