using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TipoJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }


        public Curso() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"Curso: {Nombre} {Jornada}";
        }
    }
}
