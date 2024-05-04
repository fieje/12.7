using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitTestProject1
{
    public class Student : IEquatable<Student>
    {
        public string LastName { get; set; }
        public double AverageGrade { get; set; }
        public bool HasScholarship { get; set; }

        public Student(string lastName, double averageGrade, bool hasScholarship)
        {
            LastName = lastName;
            AverageGrade = averageGrade;
            HasScholarship = hasScholarship;
        }

        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            return this.LastName == other.LastName &&
                   this.AverageGrade == other.AverageGrade &&
                   this.HasScholarship == other.HasScholarship;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Student studentObj = obj as Student;
            if (studentObj == null)
                return false;
            else
                return Equals(studentObj);
        }

        public override int GetHashCode()
        {
            return Tuple.Create(LastName, AverageGrade, HasScholarship).GetHashCode();
        }
    }

    public class Program
    {
        public static Student[] CreateStudentList()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Petrov", 4.5, true));
            students.Add(new Student("Ivanov", 3.8, false));
            students.Add(new Student("Sidorov", 4.2, true));
            students.Add(new Student("Kovalenko", 4.0, false));

            return students.ToArray();
        }

        public static Student[] FindStudentsByAverageGrade(Student[] students, double targetGrade)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in students)
            {
                if (student.AverageGrade == targetGrade)
                {
                    result.Add(student);
                }
            }

            return result.ToArray();
        }

        public static Student[] RemoveStudentsWithoutScholarship(Student[] students)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in students)
            {
                if (student.HasScholarship)
                {
                    result.Add(student);
                }
            }

            return result.ToArray();
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOriginalStudentList()
        {
            Student[] expectedStudents = new Student[]
            {
                new Student("Petrov", 4.5, true),
                new Student("Ivanov", 3.8, false),
                new Student("Sidorov", 4.2, true),
                new Student("Kovalenko", 4.0, false),
            };

            Student[] actualStudents = Program.CreateStudentList();

            CollectionAssert.AreEqual(expectedStudents, actualStudents, "Lists are not equal.");
        }

        [TestMethod]
        public void TestFindStudentsByAverageGrade()
        {
            Student[] students = new Student[]
            {
                new Student("Petrov", 4.5, true),
                new Student("Ivanov", 3.8, false),
                new Student("Sidorov", 4.2, true),
                new Student("Kovalenko", 4.0, false),
            };
            double targetGrade = 4.5;

            Student[] actualStudents = Program.FindStudentsByAverageGrade(students, targetGrade);

            Assert.AreEqual(1, actualStudents.Length);
            Assert.AreEqual("Petrov", actualStudents[0].LastName);
            Assert.AreEqual(4.5, actualStudents[0].AverageGrade);
            Assert.IsTrue(actualStudents[0].HasScholarship);
        }

        [TestMethod]
        public void TestRemoveStudentsWithoutScholarship()
        {
            Student[] students = new Student[]
            {
                new Student("Petrov", 4.5, true),
                new Student("Ivanov", 3.8, false),
                new Student("Sidorov", 4.2, true),
                new Student("Kovalenko", 4.0, false),
            };

            Student[] actualStudents = Program.RemoveStudentsWithoutScholarship(students);

            Assert.AreEqual(2, actualStudents.Length);
            Assert.AreEqual("Petrov", actualStudents[0].LastName);
            Assert.AreEqual(4.5, actualStudents[0].AverageGrade);
            Assert.IsTrue(actualStudents[0].HasScholarship);
            Assert.AreEqual("Sidorov", actualStudents[1].LastName);
            Assert.AreEqual(4.2, actualStudents[1].AverageGrade);
            Assert.IsTrue(actualStudents[1].HasScholarship);
        }
    }
}
