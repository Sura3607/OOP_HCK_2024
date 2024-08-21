using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HCK_2024
{
    public class Student
    {
        private string name;
        private float gpa;
      
        public string Name { get => name; set => name = value; }
        public float Gpa { get => gpa; set => gpa = value; }

        public Student(string name = "None", float gpa = 0f)
        {
            Name = name;
            Gpa = gpa;
        }

        public Student(Student student)
        {
            Name = student.Name;
            Gpa= student.Gpa;
        }
        public string ShowInfo()
        {
            return $"Name : {name} \t Gpa : {gpa}";
        }
        public void ShowListStudent(Student[] students)
        {
            Console.WriteLine($"STT \t | \t Name \t\t\t | \t  Gpa |");
            for(int i =0 ; i<students.Length; i++)
            {
                Console.WriteLine($"{i +1} \t | \t {students[i].Name,-20} \t | \t {students[i].Gpa,4} |");
            }
        }
        public Student[] SortStudents(Student[] students)
        {
            for (int i = 1; i < students.Length; ++i)
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
    }
}
