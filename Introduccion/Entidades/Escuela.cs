using Introduccion.Entidades;
using Introduccion.Interfaces;
using Introduccion.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Escuela : ObjetoEscuelaBase, ILugar
    {

        public int AñodDeCreacion { get; set; }

        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public string Direccion { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela() { }

        public Escuela(string nombre, int año, TipoEscuela tipo, string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñodDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        } 

        

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipos: {TipoEscuela} {System.Environment.NewLine} {Pais}, Ciudad: {Ciudad}";
        }

        // hacer
        public void LimpiarDireccion()
        {
            Printer.DrawLine();
            Printer.WriteTitle("Limpiando Escuela...");
            foreach(var curso in Cursos)
            {
                Printer.WriteTitle($"Curso {curso.LimpiarDireccion} esta limpio");

            }
        }
    }


}
