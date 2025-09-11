// See https://aka.ms/new-console-template for more information
using MyLinqRealisation_ConsoleApp;

Console.WriteLine("--- Hello, World! ---");

List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "John", Age = 18 },
    new Student { Id = 2, Name = "Alice", Age = 20 },
    new Student { Id = 3, Name = "Bob", Age = 22 }
};

var filteredStudents = students.MyWhere(student => student.Age > 18).MyWhere(student => student.Name.Equals("Bob"));
foreach (var student in filteredStudents)
{
    Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
}

Console.WriteLine("--- ---");

var persons = students.MySelect(student => new Person { Id = student.Id, Name = student.Name });
foreach (var person in persons)
{
    Console.WriteLine($"Id: {person.Id}, Name: {person.Name}");
}

Console.WriteLine("--- End ---");
