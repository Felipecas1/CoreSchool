using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public class Test
    {
        public string UniqueId { get; set; }
        public string Name { get; internal set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Calification { get; set; }

        public Test() => UniqueId = Guid.NewGuid().ToString();

        //Para escribir
        public override string ToString()
        {
            return $"{Calification}, {Student.Name}, {Subject.Name}";
        }
    }
}
