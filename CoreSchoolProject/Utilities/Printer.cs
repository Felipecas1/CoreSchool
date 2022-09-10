using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreSchoolProject.Utilities
{
    public static class Printer
    {
        public static void DrawLine(int zise = 10)
        {
            Console.WriteLine("".PadRight(zise, '='));
        }

        public static void WriteTittle(string titulo)
        {
            DrawLine(titulo.Length + 4);
            Console.WriteLine($"| {titulo} |");
            DrawLine(titulo.Length + 4);
        }
        
        public static void Beep(int hz = 2000, int time = 1000, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                Console.Beep(hz, time);
            }
        }
    }
}
