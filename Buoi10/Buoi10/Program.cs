using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Buoi10
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Bai1();

            string filePath = "data.dat";
            string finalJson = File.ReadAllText(filePath);
            StudentList finalStudentList = JsonSerializer.Deserialize<StudentList>(finalJson);
            Console.WriteLine("\nStudents List:");
            foreach (Student student in finalStudentList.Students)
            {
                Console.WriteLine(student);
            }

            //Bai2();

            //string filePath = "data.xml";
            //string finalXml;
            //using (StreamReader reader = new StreamReader(filePath))
            //{
            //    finalXml = reader.ReadToEnd();
            //}
            //StudentList finalStudentList;
            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    finalStudentList = (StudentList)xmlSerializer.Deserialize(fs);
            //}

            //Console.WriteLine("\nStudents List:");
            //foreach (Student student in finalStudentList.Students)
            //{
            //    Console.WriteLine(student);
            //}

            Console.ReadLine();
        }
        public static void Bai1()
        {
            StudentList studentList = new StudentList();
            studentList.Add(new Student { Id = 1, Name = "Nam", Age = 20 });
            studentList.Add(new Student { Id = 2, Name = "Binh", Age = 21 });
            studentList.Add(new Student { Id = 3, Name = "Minh", Age = 22 });

            //ghi
            string filePath = "data.dat";
            string json = JsonSerializer.Serialize(studentList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("Ghi thanh cong vao file data.dat.");

            //doc
            string newJson = File.ReadAllText(filePath);
            Console.WriteLine("\nNoi dung trong data.dat:");
            StudentList newstudentlist = JsonSerializer.Deserialize<StudentList>(newJson);
            foreach (Student student in newstudentlist.Students)
            {
                Console.WriteLine(student);
            }

            ////them vai sv de add vao file
            //newstudentlist.Add(new Student { Id = 4, Name = "An", Age = 23 });
            //newstudentlist.Add(new Student { Id = 5, Name = "Thuy", Age = 24 });

            ////them du lieu moi
            //string updatedJson = JsonSerializer.Serialize(newstudentlist, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText(filePath, updatedJson);
            //Console.WriteLine("\nDa them du lieu moi vao data.dat.");

            ////deserializer
            //string finalJson = File.ReadAllText(filePath);
            //StudentList finalStudentList = JsonSerializer.Deserialize<StudentList>(finalJson);
            //Console.WriteLine("\nStudents List:");
            //foreach (Student student in finalStudentList.Students)
            //{
            //    Console.WriteLine(student);
            //}
        }
        public static void Bai2()
        {
            StudentList studentList = new StudentList();
            studentList.Add(new Student { Id = 1, Name = "Nam", Age = 20 });
            studentList.Add(new Student { Id = 2, Name = "Binh", Age = 21 });
            studentList.Add(new Student { Id = 3, Name = "Minh", Age = 22 });

            //ghi
            string filePath = "data.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentList));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, studentList);
            }
            Console.WriteLine("Ghi thanh cong vao file data.xml.");

            //doc va des
            string newXml;
            using (StreamReader reader = new StreamReader(filePath))
            {
                newXml = reader.ReadToEnd();
            }
            StudentList newstudentlist;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                newstudentlist = (StudentList)xmlSerializer.Deserialize(fs);
            }
            Console.WriteLine("\nNoi dung trong data.xml:");
            foreach (Student student in newstudentlist.Students)
            {
                Console.WriteLine(student);
            }

            ////them vai sv de add vao file
            //newstudentlist.Add(new Student { Id = 4, Name = "An", Age = 23 });
            //newstudentlist.Add(new Student { Id = 5, Name = "Thuy", Age = 24 });

            ////them du lieu moi
            //using (FileStream fs = new FileStream(filePath, FileMode.Create))
            //{
            //    xmlSerializer.Serialize(fs, newstudentlist);
            //}
            //Console.WriteLine("\nDa them du lieu moi vao data.xml.");

            ////deserializer
            //string finalXml;
            //using (StreamReader reader = new StreamReader(filePath))
            //{
            //    finalXml = reader.ReadToEnd();
            //}
            //StudentList finalStudentList;
            //using (FileStream fs = new FileStream(filePath, FileMode.Open))
            //{
            //    finalStudentList = (StudentList)xmlSerializer.Deserialize(fs);
            //}

            //Console.WriteLine("\nStudents List:");
            //foreach (Student student in finalStudentList.Students)
            //{
            //    Console.WriteLine(student);
            //}
        }
    }
}
