using Introduccion.Interfaces;
using Introduccion.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {
        public TipoJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }


        public Curso() { }

        public override string ToString()
        {
            return $"Curso: {Nombre} {Jornada}";
        }

        public void LimpiarDireccion()
        {
            Printer.DrawLine();
            Printer.WriteTitle("Limpiando Direccion...");
            Printer.WriteTitle($"Curso {Nombre} esta limpio");

        }
    }
}
