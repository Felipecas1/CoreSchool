using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Entities
{
    public class School
    {
        public string UniqueId { get; set; } = Guid.NewGuid().ToString();
        string? name;
        public string Name { get { return "Copia: " + name; } set { name = value.ToUpper(); } }
        public int YearOfFundation { get; set; }
        //public string Country { get { return "Colombia"; } set { Country = value; } } //Si quiero que si o si sea COLOMBIA
        public string? Country { get; set; }
        public string? City { get; set; }
        public SchoolType SchoolType { get; set; }
        public List<Course> Courses { get; set; }
        //creo un constructor para que creen ESCUELAS de cierta forma si o si
        //FUNCION LAMBDA
        public School(string name, int year, string city) => (Name,YearOfFundation) = ( name, year);
        public School(string name, int year, SchoolType type, string country = "", string city = "") : base()
        {
            (Name, YearOfFundation) = (name, year);
            Country = country;
            City = city;
            //Pongo this cuando el argumento se llama igual a la propiedad
        }
        public override string ToString()
        {
            return $"Nombre de la escuela \"{Name}\", tipo de escuela {SchoolType}{System.Environment.NewLine}País de la escuela {Country}, la ciudad es {City}";
        }
        //Console.WriteLine($"Tu país es {Country}"); //Me imprime lo que este en el metodo
    }
}