using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoreSchoolProject.Entities
{
    public class Course
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public TimeType Time { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        
        //constructor
        public Course()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
        /*public override string ToString()
        {
            return $"El nombre del curso es: {Name} y su ID es: {UniqueId}";
        }*/
    }
}
