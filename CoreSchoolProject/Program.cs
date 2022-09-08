using CoreSchoolProject.Entities;
using CoreSchoolProject.Utilities;
using System;
using System.Reflection.Metadata;
using static System.Console;

var engine = new EngineSchool();
engine.Initialize();
Printer.WriteTittle("Welcome to the School");
Printer.Beep(5000, 500, 2);

PrintSchoolCourses(engine.School);
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