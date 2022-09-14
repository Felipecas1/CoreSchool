using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public class Test : BaseSchoolObject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Calification { get; set; }

        //Ya inicializa la padre.
        //public Test() => UniqueId = Guid.NewGuid().ToString();

        //Para escribir
        public override string ToString()
        {
            return $"{Calification:N2}, {Student.Name}, {Subject.Name}";
        }
    }
}
