// See https://aka.ms/new-console-template for more information
using MyLinqRealisation_ConsoleApp;
using Enumerable = MyLinqRealisation_ConsoleApp.Enumerable;

Console.WriteLine("--- Hello, World! ---");

List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "John", Age = 18 },
    new Student { Id = 2, Name = "Alice", Age = 20 },
    new Student { Id = 3, Name = "Bob", Age = 22 }
};

// Filter is another name of Where function
//var filteredStudents = students.Filter(student => student.Age > 18);
//var filteredStudents = students.Filter(student => student.Age > 18).Filter(student => student.Name.Equals("Bob"));

//var filteredStudents = Enumerable.Where(Enumerable.Where(students, student => student.Age > 18), student => student.Name.Equals("Bob"));
var filteredStudents = students.MyWhere(student => student.Age > 18).MyWhere(student => student.Name.Equals("Bob"));

foreach (var student in filteredStudents)
{
    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
}

Console.WriteLine("--- End ---");
