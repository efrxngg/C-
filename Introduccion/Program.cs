using Introduccion.App;
using Introduccion.Entidades;
using Introduccion.Interfaces;
using Introduccion.Test;
using Introduccion.util;
using System.Collections.Generic;
using System.Numerics;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
        var engine = new EscuelaEngine();
        engine.Inicializar();

        int dummy = 0;
        var listaObjetos = engine.GetObjetoEscuelaBases(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            out int conteoAlumnos
        );
        //engine.objEscuela.LimpiarDireccion();

        //var listaILugar = from obj in listaObjetos
        //                  where obj is ILugar
        //                  select (ILugar) obj;

        //PruebasPolimorfismo();
        Printer.WriteTitle("Pruebas diccionario");
        //diccionarioPruebas();
        //diccionarioPruebas2();
        engine.ImprimirDiccionario(engine.GetDiccionarioObjetos());
        var reportador = new Reportador(engine.GetDiccionarioObjetos());
        reportador.GetListaEvaluaciones();
        

        //TestStaticContructors();
    }

    private static void AccionDelEvento(object? sender, EventArgs e)
    {
        Printer.WriteTitle("Saliendo");
        Printer.Beep(3000, 1000);
        Printer.WriteTitle("Salio");

    }

    private static void PruebasPolimorfismo()
    {
        Printer.DrawLine(30);
        Printer.WriteTitle("Pruebas Polimorfismo");

        var alumno = new Alumno { Nombre = "Efren" };
        ObjetoEscuelaBase objEB = alumno;

        Printer.WriteTitle("Alumno");
        WriteLine(alumno.UniqueId);
        WriteLine(alumno.Nombre);
        WriteLine(alumno.GetType());

        Printer.WriteTitle("Escula Base");
        WriteLine(objEB.UniqueId);
        WriteLine(alumno.Nombre);
        WriteLine(objEB.Nombre);
        WriteLine(objEB.GetType());
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
       
    private static void diccionarioPruebas()
    {
        Dictionary<int, string> diccionario = new Dictionary<int, string>();
        diccionario.Add(1, "Efren");
        diccionario.Add(2, "Gisell");

        foreach(var KeyValPair in diccionario)
        {
            WriteLine($"{KeyValPair.Key} {KeyValPair.Value}");

        }

        WriteLine(diccionario[1]);
    }

    private static void diccionarioPruebas2()
    {
        Dictionary<string, string> diccionario = new Dictionary<string, string>();
        diccionario.Add("efrxngg", "Efren");
        diccionario.Add("none", "Gisell");
        diccionario["null"] = "Dario";

        foreach (var KeyValPair in diccionario)
        {
            WriteLine($"{KeyValPair.Key} {KeyValPair.Value}");
        }

        WriteLine(diccionario["null"]);
    }

    private static void TestStaticContructors()
    {
        Bus bus1 = new Bus(71);

        // Create a second bus.
        Bus bus2 = new Bus(72);

        // Send bus1 on its way.
        bus1.Drive();

        // Wait for bus2 to warm up.
        System.Threading.Thread.Sleep(25);

        // Send bus2 on its way.
        bus2.Drive();

        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}