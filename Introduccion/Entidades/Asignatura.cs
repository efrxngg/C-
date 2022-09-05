using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Asignatura: ObjetoEscuelaBase
    {
        public Asignatura() { }

        public override string ToString()
        {
            return $"{Nombre}";
        }
    }
}
