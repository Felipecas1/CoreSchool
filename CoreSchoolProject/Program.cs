using CoreSchoolProject.App;
using CoreSchoolProject.Entities;
using CoreSchoolProject.Utilities;
using System;
using System.Reflection.Metadata;
using static System.Console;

AppDomain.CurrentDomain.ProcessExit += EventAction;
AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(1000,1000,1);
AppDomain.CurrentDomain.ProcessExit -= EventAction;

var engine = new EngineSchool();
engine.Initialize();
Printer.WriteTittle("Welcome to the School");
//Printer.Beep(5000, 500, 2);

//PrintSchoolCourses(engine.School);

var reporter = new Reporter(engine.GetObjectDictionary());
var testList = reporter.GetListTests();
var subjectList = reporter.GetListSubjecst();
var subXTeList = reporter.GetDicTestXSubject();

//engine.School.CleanPlace();

//evento como delegado.
void EventAction(object? sender, EventArgs e)
{
    Printer.WriteTittle("Exit...");
    Printer.Beep(2000, 1000, 3);
    Printer.WriteTittle("Left");
}

///<summary>
void PrintSchoolCourses(School school)
{
    Printer.WriteTittle("School course");

    if (school?.Courses == null)
        return;
    else
    {
        foreach (var course in school.Courses)
        {
            WriteLine($"Nombre curso: {course.Name}, ID: {course.UniqueId}");
        }
    }
}
///</ summary >

///<example>

//school.Courses.AddRange(otraColeccion);//Adiciono otra lista
//Course tempo = new Course { Name = "101 - Vacacional", Time = TimeType.Night };
//school.Courses.Add(tempo);
//school.Courses.Remove(tempo);

//cuando utilizo el pedricate - Asegura los parametros que debe llevar la funcion para ejecutarse
//Predicate<Course> miAlgoritmo = Predicado;

/*school.Courses.RemoveAll(delegate (Course cur) { return cur.Name == "301"; }); //delegado dentro del algoritmo
school.Courses.RemoveAll((cur) => cur.Name == "501" && cur.Time == TimeType.Morning); //funcion lambda*/

//Removiendo con un delegado, creando el metodo
/*school.Courses.RemoveAll(Predicate)
bool Predicate(Course curobj)
{
    return curobj.Name == "301";
}*/
///</example>
///

/*
///<example>
Printer.WriteTittle("Pruebas de polimorfismo");

var studentTest = new Student() { Name = "Claire Underwood" };

Printer.WriteTittle("Student");
Console.WriteLine("Student: " + studentTest.Name);
Console.WriteLine("Student: " + studentTest.UniqueId);
Console.WriteLine("Student: " + studentTest.GetType());

BaseSchoolObject obj = studentTest;

Printer.WriteTittle("School Object");
Console.WriteLine("Student: " + obj.Name);
Console.WriteLine("Student: " + obj.UniqueId);
Console.WriteLine("Student: " + obj.GetType());

var objDummy = new BaseSchoolObject();

objDummy.Name = "Frank Underwood";
Printer.WriteTittle("Base school object");
Console.WriteLine("Student: " + objDummy.Name);
Console.WriteLine("Student: " + objDummy.UniqueId);
Console.WriteLine("Student: " + objDummy.GetType());

var tests = new Test() { Name = "Math test", Calification = 4.5f };
Printer.WriteTittle("TEST");
Console.WriteLine("Test: " + tests.Name);
Console.WriteLine("Test: " + tests.UniqueId);
Console.WriteLine("Test: " + tests.Calification);
Console.WriteLine("Test: " + tests.GetType());

obj = tests;

Printer.WriteTittle("School Object");
Console.WriteLine("Student: " + obj.Name);
Console.WriteLine("Student: " + obj.UniqueId);
Console.WriteLine("Student: " + obj.GetType());

if (obj is Student)
{
    Student recoveredStudent = (Student)obj;
}
///</example>
*/

//Example
/*Con esta funcion podemos llamar a unos datos en especifico
var listaIPlace = from obj in objetcList
                  where obj is Student
                  select (Student) obj;
*/

/*EXAMPLE DICTIONARY
Printer.WriteTittle("Access to dictionary");

dictionary[0] = "Papi Pipe";
WriteLine(dictionary[0]);

Printer.WriteTittle("Other dictionary");

var dic = new Dictionary<string, string>();
dic["Luna"] = "Cuerpo celeste que gira alrededor de la tierra";
WriteLine(dic["Luna"]);

//dic.Add("Luna", "Protagonista de Soy Luna"); //No puedo agregar otro valor igual

dic["Luna"] = "Protagonista de Soy Luna"; //Puedo agregar otra definicion
WriteLine(dic["Luna"]);
*/