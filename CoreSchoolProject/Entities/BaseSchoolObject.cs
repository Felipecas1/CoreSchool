using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public abstract class BaseSchoolObject
    {
        public string UniqueId { get; private set; } //UniqueId = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public BaseSchoolObject()
        {
            UniqueId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name}, {UniqueId}";
        }
    }
}