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
        public Student(string id, string name, string place_of_birth, DateTime birthday, float gpa) : base(name, place_of_birth, birthday)
        {
            this.id = id;
            this.gpa = gpa;
        }
        public Student(Student student) : base(student)
        {
            this.id = student.Id;
            this.gpa = student.Gpa;
        }

        
    }
}
