using CoreSchoolProject.Entities;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

public class EngineSchool
{
    public School School { get; set; }

    public EngineSchool()
	{
		
    }

	public void Initialize()
    {
        School = new School(name: "Platzi School", year: 2012, SchoolType.Elementary, city: "Bogotá", country: "Colombia");

        UploadCourses();
        UploadSubjects();
        UploadTests();
    }

    private void UploadTests()
    {
        var lista = new List<Test>();
        foreach (var course in School.Courses)
        {
            foreach (var subject in course.Subjects)
            {
                foreach (var student in course.Students)
                {
                    Random random = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        var test = new Test();
                        test.Subject = subject;
                        test.Name = $"{subject.Name} Test# {i + 1}";
                        test.Calification = (float)(random.NextDouble() * 5);
                        test.Student = student;

                        student.Tests.Add(test);
                    }
                }
            }
        }
    }

    private void UploadSubjects()
    {
        foreach (var course in School.Courses)
        {
            List<Subject> subjecstList = new List<Subject>()
            {
                new Subject() { Name = "Math" },
                new Subject() { Name = "Spanish" },
                new Subject() { Name = "Sciencies" },
                new Subject() { Name = "Sports" }
            };
            course.Subjects = subjecstList;
        }
    }

    private List<Student> GenerateStudentsRandom(int cantidad)
    {
        string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
        string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
        string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

        var studentList = from n1 in nombre1
                          from n2 in nombre2
                          from a1 in apellido1
                          select new Student { Name = $"{n1} {n2} {a1}" };
        
        return studentList.OrderBy(al => al.UniqueId).Take(cantidad).ToList();
    }

    private void UploadCourses()
    {
        School.Courses = new List<Course>()
        {
            new Course() { Name = "101", Time = TimeType.Morning },
            new Course() { Name = "201", Time = TimeType.Morning },
            new Course() { Name = "301", Time = TimeType.Morning },
            new Course() { Name = "401", Time = TimeType.Afternoon },
            new Course() { Name = "501", Time = TimeType.Afternoon },
        };

        Random rnd = new Random();

        foreach (var c in School.Courses)
        {
            int cantRandom = rnd.Next(5, 20);
            c.Students = GenerateStudentsRandom(cantRandom);
        }
    }
}