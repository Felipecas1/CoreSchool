using CoreSchoolProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoreSchoolProject.Entities
{
    public class Course : BaseSchoolObject, IPlace
    {
        public TimeType Time { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }

        //constructor
        public Course()
        {

        }

        public void CleanPlace()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning business place");
            Console.WriteLine($"Course: {Name} is clean");
        }


        /*public override string ToString()
        {
            return $"El nombre del curso es: {Name} y su ID es: {UniqueId}";
        }*/
    }
}
