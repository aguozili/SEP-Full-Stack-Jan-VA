using DesigningClasses;
using Microsoft.OData.Edm;

//Student a = new Student();
//a.Address = new List<string> { "123 st", "53st" };
//a.Address.Add("50 st");
//a.GetAddress(a.Address);

//a.DateOfBirth = new DateTime(1995, 10, 9);
//Console.WriteLine(a.Age);


//Instructor b = new Instructor();
//b.Id = 1;
//b.Name = "Harry";
//Console.WriteLine(b.Name);

Student student = new Student();
student.Name = "Bill";
student.Id = 1;
student.Salary = 100;

Course pianoCourse = new Course();
pianoCourse.Name = "Piano";
pianoCourse.Id = 66;

Course violinCourse = new Course();
pianoCourse.Name = "Violin";
pianoCourse.Id = 77;

student.SelectedCourses = new List<Course>();
student.SelectedCourses.Add(pianoCourse);
student.SelectedCourses.Add(violinCourse);

pianoCourse.EnrolledStudent = new List<Student>() { student };


foreach(var item in pianoCourse.EnrolledStudent)
{
    Console.WriteLine(item.Name);
}

Department department = new Department();
department.Id = 2;




