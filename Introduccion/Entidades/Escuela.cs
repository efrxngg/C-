using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        private string nombre;
        private TipoEscuela tipoEscuela;
        private List<Curso> cursos;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }

        }
        public int AñodDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TipoEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
       

        public Escuela(string nombre, int año) => (Nombre, AñodDeCreacion) = (nombre, año);

        public Escuela(string nombre, int año, TipoEscuela tipo, string pais = "", string ciudad = "") : base()
        {
            (Nombre, AñodDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        public Escuela()
        {
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipos: {TipoEscuela} {System.Environment.NewLine} {Pais}, Ciudad: {Ciudad}";
        }

    }


}
