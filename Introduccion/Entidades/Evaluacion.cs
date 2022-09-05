using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Evaluacion : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Nota { get; set; }

        public Evaluacion() { }

        public override string ToString()
        {
            return $"{Nombre} {Alumno.Nombre} {Asignatura.Nombre} {Nota}";
        }
    }
}
