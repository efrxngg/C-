using Introduccion.App;
using Introduccion.Entidades;
using Introduccion.util;
using System.Collections.Generic;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        var engine = new EscuelaEngine();
        engine.Inicializar();

    }




    /// <summary>
    ///     Recorre los cursos de una escuela
    /// </summary>
    /// <param name="objEscuela"></param>
    static void RecorreCursosEscuela(Escuela objEscuela)
    {
        Printer.WriteTitle(objEscuela.Nombre);

        foreach (Curso curso in objEscuela.Cursos)
        {
            WriteLine($"{curso.Nombre} {curso.Jornada}");
        }
        Printer.Beep();
    }


    private static void ExpresionesLambda()
    {
        //WriteLine($"Coincidencia: {objEscuela.Cursos.Find(delegate (Curso cur) { return cur.Nombre == "301"; })}");
        ////Exprecion lambda
        //WriteLine($"Coincidencia: {objEscuela.Cursos.Find((cur) => cur.Nombre == "200")}");
    }

}