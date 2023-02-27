using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Читання даних з файлу CSV та зберігання їх у списку студентів
        List<Student> students = new List<Student>();
        using (StreamReader reader = new StreamReader("students.csv"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Student student = new Student
                {
                    Name = parts[0],
                    Grade1 = int.Parse(parts[1]),
                    Grade2 = int.Parse(parts[2]),
                    Grade3 = int.Parse(parts[3])
                };
                students.Add(student);
            }
        }

        // Використання лямбда-виразу для фільтрації студентів з середнім балом більше 80
        var topStudents = students.Where(s => (s.Grade1 + s.Grade2 + s.Grade3) / 3.0 >= 80);

        // Виведення результатів фільтрації на консоль
        foreach (var student in topStudents)
        {
            Console.WriteLine("{0} - середній бал: {1}", student.Name, (student.Grade1 + student.Grade2 + student.Grade3) / 3.0);
        }
    }
}

class Student
{
    public string Name { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
    public int Grade3 { get; set; }
}
