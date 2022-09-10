using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public class Student : BaseSchoolObject
    {
        public List<Test> Tests { get; set; }
        //public Student() => (UniqueId, Tests) = (Guid.NewGuid().ToString(), new List<Tests>());

        public Student() => Tests = new List<Test>();
    }
}
