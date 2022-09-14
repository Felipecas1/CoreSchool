using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    internal interface IPlace
    {
        string Address { get; set; }

        void CleanPlace();
    }
}
