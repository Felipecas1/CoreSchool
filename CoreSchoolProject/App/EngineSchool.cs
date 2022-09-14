using CoreSchoolProject.Entities;
using CoreSchoolProject.Utilities;

public sealed class EngineSchool
{
    public School School { get; set; }

    public EngineSchool()
    {

    }

    public void PrintDictionary(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dic,
        bool printtest = false)
    {
        foreach (var obj in dic)
        {
            Printer.WriteTittle(obj.Key.ToString());

            foreach (var val in obj.Value)
            {
                switch (obj.Key)
                {
                    case KeyDictionary.Test:
                        if (printtest)
                            Console.WriteLine(val);
                        break;
                    case KeyDictionary.School:
                        Console.WriteLine($"School: {val}");
                        break;
                    case KeyDictionary.Course:
                        var coursetmp = val as Course;
                        if (coursetmp != null)
                        {
                            var count = coursetmp.Students.Count;
                            Console.WriteLine($"Course: {val.Name}. Number of students: {count}");
                        }
                        break;
                    case KeyDictionary.Student:
                        Console.WriteLine($"Nombre: {val.Name}");
                        break;
                    default:
                        Console.WriteLine(val);
                        break;
                }
            }
        }
    }

    public Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> GetObjectDictionary()
    {
        var dictionary = new Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>>();
        dictionary.Add(KeyDictionary.School, new[] { School });
        dictionary.Add(KeyDictionary.Course, School.Courses); //Acá usamos el Cast() porque esta esperando una lista BaseSchoolObject, no una de cursos. para que haga la conversion de que curso es compatible con BaseSchoolObject

        //una forma de hacer el foreach con lambda
        var listatmptests = new List<Test>();
        var listatmpsubject = new List<Subject>();
        var listatmpstudent = new List<Student>();
        School.Courses.ForEach(courses =>
        {
            listatmpsubject.AddRange(courses.Subjects);
            listatmpstudent.AddRange(courses.Students);
            courses.Students.ForEach(student => listatmptests.AddRange(student.Tests));
        });
        dictionary.Add(KeyDictionary.Test, listatmptests);
        dictionary.Add(KeyDictionary.Subject, listatmpsubject);
        dictionary[KeyDictionary.Student] = listatmpstudent;


        //foreach (var course in School.Courses)
        //{
        //    dictionary[KeyDictionary.Student] = course.Students;
        //    dictionary.Add(KeyDictionary.Subject, course.Subjects);
        //}

        return dictionary;

    }

    public void Initialize()
    {
        School = new School(name: "Platzi School", year: 2012, SchoolType.Elementary, city: "Bogotá", country: "Colombia");

        UploadCourses();
        UploadSubjects();
        UploadTests();
    }

    public IReadOnlyList<BaseSchoolObject> GetBaseSchoolObjects(
        bool bringTests = true,
        bool bringStudents = true,
        bool bringSubjects = true,
        bool bringCourses = true
        )
    {
        return GetBaseSchoolObjects(out int dummy, out dummy, out dummy, out dummy);
    }

    public IReadOnlyList<BaseSchoolObject> GetBaseSchoolObjects(
        out int countTests,
        bool bringTests = true,
        bool bringStudents = true,
        bool bringSubjects = true,
        bool bringCourses = true
        )
    {
        return GetBaseSchoolObjects(out countTests, out int dummy, out dummy, out dummy);
    }

    public IReadOnlyList<BaseSchoolObject> GetBaseSchoolObjects(
        out int countTests,
        out int countSubjects,
        bool bringTests = true,
        bool bringStudents = true,
        bool bringSubjects = true,
        bool bringCourses = true
        )
    {
        return GetBaseSchoolObjects(out countTests, out countSubjects, out int dummy, out dummy);
    }

    public IReadOnlyList<BaseSchoolObject> GetBaseSchoolObjects(
        out int countTests,
        out int countSubjects,
        out int countStudents,
        bool bringTests = true,
        bool bringStudents = true,
        bool bringSubjects = true,
        bool bringCourses = true
        )
    {
        return GetBaseSchoolObjects(out countTests, out countSubjects, out countStudents, out int dummy);
    }

    public IReadOnlyList<BaseSchoolObject> GetBaseSchoolObjects(
        out int countTests,
        out int countSubjects,
        out int countStudents,
        out int countCourses,
        bool bringTests = true,
        bool bringStudents = true,
        bool bringSubjects = true,
        bool bringCourses = true
        )
    {
        countTests = countSubjects = countStudents = 0;

        var listaObj = new List<BaseSchoolObject>();
        listaObj.Add(School);

        if (bringCourses)
            listaObj.AddRange(School.Courses);

        countCourses = School.Courses.Count;

        foreach (var course in School.Courses)
        {
            countSubjects += course.Subjects.Count;
            countStudents += course.Students.Count;

            if (bringSubjects)
                listaObj.AddRange(course.Subjects);

            if (bringStudents)
                listaObj.AddRange(course.Students);

            if (bringTests)
            {
                foreach (var student in course.Students)
                {
                    listaObj.AddRange(student.Tests);
                    countTests += student.Tests.Count;
                }
            }
        }
        return listaObj.AsReadOnly();
    }
    #region UploadingMethods
    private void UploadTests()
    {
        Random random = new Random();
        var lista = new List<Test>();
        foreach (var course in School.Courses)
        {
            foreach (var subject in course.Subjects)
            {
                foreach (var student in course.Students)
                {
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
#endregion