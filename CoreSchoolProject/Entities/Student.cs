using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public class Student
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }
        public List<Tests> Tests { get; set; }
        //public Student() => (UniqueId, Tests) = (Guid.NewGuid().ToString(), new List<Tests>());

        public Student()
        {
            UniqueId = Guid.NewGuid().ToString();
            Tests = new List<Tests>();
        }
    }
}
