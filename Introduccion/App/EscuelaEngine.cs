
using Introduccion.Entidades;
using Introduccion.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduccion.App
{
    public class EscuelaEngine
    {
        public Escuela objEscuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            objEscuela = new Escuela("Escuela X", 2012, TipoEscuela.Secundaria, ciudad: "Bogota", pais: "Colombia");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
            Console.WriteLine(objEscuela);
        }

        private void CargarEvaluaciones()
        {
            Random random = new Random();

            foreach (Curso curso in objEscuela.Cursos)
            {
                foreach(var alumno in curso.Alumnos)
                {
                    alumno.Evaluaciones = new List<Evaluacion>();
                    foreach(var asignatura in curso.Asignaturas)
                    {
                        alumno.Evaluaciones.Add(new Evaluacion()
                        {
                            Nombre = curso.Nombre,
                            Alumno = alumno,
                            Asignatura = asignatura,
                            Nota = (float)random.NextDouble() * 5          
                        });
                    }
                    Console.WriteLine("\n");
                    foreach (var evaluacion in alumno.Evaluaciones)
                    {
                        Console.WriteLine(evaluacion.ToString());
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach(var curso in objEscuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matematicas"},
                    new Asignatura{Nombre = "Lengua y Literatura"},
                    new Asignatura{Nombre = "Educacion Fisica"},
                    new Asignatura{Nombre = "Ingles"},
                    new Asignatura{Nombre = "Computacion"}
                };

                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] nombre1 = { "Efren", "Gisell", "Dario", "Perro" };
            string[] apellido1 = { "Galarza", "Castro", "Carpio", "Negro"};

            var listaAlumnos = from n1 in nombre1
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {a1}" };

            return listaAlumnos.OrderBy( (al)=>al.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            objEscuela.Cursos = new List<Curso>() {
                new Curso{ Nombre = "404", Jornada = TipoJornada.Mañana },
                new Curso{ Nombre = "505", Jornada = TipoJornada.Tarde },
                new Curso{ Nombre = "500", Jornada = TipoJornada.Noche },
                new Curso{ Nombre = "200", Jornada = TipoJornada.Tarde },
                new Curso{ Nombre = "101", Jornada = TipoJornada.Tarde }
            };

            Random random = new Random();
            foreach(Curso curso in objEscuela.Cursos)
            {
                curso.Alumnos = GenerarAlumnos(random.Next(1, 20));
            }
        }
    }
}
