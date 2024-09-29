using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Buoi10
{
    [Serializable]
    public class StudentList : ISerializable
    {
        private List<Student> students = new List<Student>();
        public List<Student> Students { get => students; set => students = value; }
        public StudentList() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Students", Students);
        }
        public StudentList(SerializationInfo info, StreamingContext context)
        {
            Students = (List<Student>)info.GetValue("Students", typeof(List<Student>));
        }
        public void Add(Student item)
        {
            Students.Add(item);
        }
    }
}
