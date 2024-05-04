using System;

class Student
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
}

class Program
{
    static Student[] CreateStudentList()
    {
        return new Student[]
        {
            new Student("Petrov", 4.5, true),
            new Student("Ivanov", 3.8, false),
            new Student("Sidorov", 4.2, true),
            new Student("Kovalenko", 4.0, false),
        };
    }

    static void PrintStudents(Student[] students, string message)
    {
        Console.WriteLine(message);
        foreach (var student in students)
        {
            Console.WriteLine($"Last Name: {student.LastName}, Average Grade: {student.AverageGrade}, Scholarship: {(student.HasScholarship ? "Yes" : "No")}");
        }
        Console.WriteLine();
    }

    static Student[] FindStudentsByAverageGrade(Student[] students, double targetGrade)
    {
        return Array.FindAll(students, student => student.AverageGrade == targetGrade);
    }

    static Student[] RemoveStudentsWithoutScholarship(Student[] students)
    {
        return Array.FindAll(students, student => student.HasScholarship);
    }

    static void Main(string[] args)
    {
        var students = CreateStudentList();

        PrintStudents(students, "Original list of students:");

        double targetGrade = 4.5;
        var studentsWithTargetGrade = FindStudentsByAverageGrade(students, targetGrade);
        PrintStudents(studentsWithTargetGrade, $"Students with average grade {targetGrade}:");

        var studentsWithScholarship = RemoveStudentsWithoutScholarship(students);
        PrintStudents(studentsWithScholarship, "Students with scholarship:");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
