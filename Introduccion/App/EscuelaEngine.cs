
using Introduccion.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Introduccion.Entidades;
using Microsoft.VisualBasic;

namespace Introduccion.App
{
    //No permite que la clase sea instanciada
    public sealed class EscuelaEngine
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
        #region Cargas
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
        #endregion

        public List<ObjetoEscuelaBase> GetObjetoEscuelaBases()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(objEscuela);
            listaObj.AddRange(objEscuela.Cursos);
            
            foreach(Curso curso in objEscuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);
                foreach(var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }
            return listaObj;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos,
            bool traeEvaluacionses = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            conteoEvaluaciones = 0;
            conteoAsignaturas = 0;
            conteoCursos = 0;
            conteoAlumnos = 0;

            listaObj.Add(objEscuela);
            if (traeCursos)
            {
               conteoCursos += objEscuela.Cursos.Count();
               listaObj.AddRange(objEscuela.Cursos);
            }

            foreach (Curso curso in objEscuela.Cursos)
            {
                if (traeAsignaturas) {
                    conteoAsignaturas += curso.Asignaturas.Count();
                    listaObj.AddRange(curso.Asignaturas);
                }

                if (traeAlumnos)
                {
                    conteoAlumnos += curso.Alumnos.Count();
                    listaObj.AddRange(curso.Alumnos);
                }

                if (traeEvaluacionses)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count();
                    }
                }
            }
            return listaObj;
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            bool traeEvaluacionses = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelaBases(out int dummy, out dummy, out dummy, out dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            bool traeEvaluacionses = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true
            )
        {
            return GetObjetoEscuelaBases(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            IEnumerable<ObjetoEscuelaBase> listaObj = new List<ObjetoEscuelaBase>();
            List<Curso> listaCurso = new List<Curso>();

            listaObj = listaCurso.Cast<ObjetoEscuelaBase>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { objEscuela });
            diccionario.Add(LlaveDiccionario.Curso, objEscuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listaTemp = new List<Evaluacion>();
            var listaTempAlumnos = new List<Alumno>();
            var listaTempAsignaturas = new List<Asignatura>();

            foreach (var cur in objEscuela.Cursos)
            {
                listaTempAsignaturas.AddRange(cur.Asignaturas);
                listaTempAlumnos.AddRange(cur.Alumnos);

                foreach (var alumno in cur.Alumnos)
                {
                    listaTemp.AddRange(alumno.Evaluaciones);

                }
            }
            diccionario.Add(LlaveDiccionario.Asignatura, listaTempAsignaturas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listaTempAlumnos.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluaciones, listaTemp);

            return diccionario;
        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool imprimirEva = false)
        {
            Console.WriteLine("start=======================");
            foreach(var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());

                foreach (var val in obj.Value)
                {
                    //switch (val.GetType())
                    //{
                    //    case Evaluacion:
                    //        break;
                    //}

                    if (val is Evaluacion)
                    {
                        if (imprimirEva)
                        {
                            Console.WriteLine(val);
                            Console.WriteLine($"Evaluacion: {val}");


                        }
                    }
                    else if( val is Escuela)
                    {
                        Console.WriteLine(val);
                        Console.WriteLine($"Escuela: {val}");

                    }
                    else if(val is Alumno)
                    {
                        Console.WriteLine($"Alumno: {val.Nombre}");

                    }
                    else
                    {
                        Console.WriteLine($"{val}");
                    }
                }
            }
        }
    }
}
