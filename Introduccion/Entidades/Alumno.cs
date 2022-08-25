using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }

        public Alumno() => Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre}";
        }
    }
}
