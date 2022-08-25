using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Asignatura
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Asignatura() => Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Nombre}";
        }
    }
}
