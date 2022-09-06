using ConsumoApiSpotify.App;
using ConsumoApiSpotify.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsumoApiSpotify.Menus
{
    public class MenuBusqueda
    {
        private SpotifyServicesImpl spotifyServices = new();
        private Printer printer = new();

        public void Run()
        {
            var opcion = MostrarMenu(new List<string>
                        {
                            "Revisar lista de artista por busqueda",
                            "Revisar Popularidad por busqueda de artista ",
                            "Revisar seguidores por busqueda de artista ",
                            "Salir"
                        },
                            "Selecione una opcion: "
                    );

            switch (opcion)
            {
                case 1:
                    {

                        BusquedaNormal();
                        Run();
                        break;
                    }
                case 2:
                    {
                        BusquedaPopular();
                        Run();
                        break;
                    }
                case 3:
                    {
                        BusquedaFollow();
                        Run();
                        break;
                    }
                case 4:
                    {
                        Clear();
                        WriteLine("Adios");
                        break;
                    }

                default:
                    {
                        WriteLine($"Opcion invalida {opcion}");
                        Run();
                        break;
                    }

            }
        }

        private void BusquedaNormal()
        {
            var consulta = SolicitarOpcion("Ingres el nombre del artista");
            printer.DrawHeadAndBody("Resultados de la Consulta", spotifyServices.GetAllArtistByName(consulta));
            DetenerFlujo();
        }

        private void BusquedaPopular()
        {
            var consulta = SolicitarOpcion("Ingres el nombre del artista");
            printer.DrawHeadAndBody("Resultados de la Consulta", spotifyServices.GetAllArtitstByNamePopular(consulta), popularity:true);
            DetenerFlujo();
        }

        private void BusquedaFollow()
        {
            var consulta = SolicitarOpcion("Ingres el nombre del artista");
            printer.DrawHeadAndBody("Resultados de la Consulta", spotifyServices.GetAllArtitstByNameFollows(consulta), follows: true);
            DetenerFlujo();
        }

        private static void DetenerFlujo()
        {
            WriteLine("Precion Enter Para Volver");
            ReadLine();
        }

        private void MostrarMenuOpciones(List<string> opciones)
        {
            printer.DrawHeadAndBody("Opciones de Busqueda", opciones);
        }

        private string SolicitarOpcion(string mensaje)
        {
            WriteLine(mensaje);
            var input = Console.ReadLine();
            return input;
        }

        private int MostrarMenu(List<string> opciones, string msg)
        {
            MostrarMenuOpciones(opciones);
            var opcion = SolicitarOpcion(msg);

            return ValidarOpcion(opciones.Count(), opcion); ;
        }

        private int ValidarOpcion(int lenOpciones, string opcion)
        {
            int opcionSelect = 0;
            try
            {
                opcionSelect = Convert.ToInt32(opcion);
            }
            catch (FormatException e) { WriteLine("La opcion selecionada es invalida"); }
            catch (OverflowException e) { WriteLine("La opcion ingresada genero un desbordamiento"); }

            if (opcionSelect > 0 && opcionSelect <= lenOpciones)
            {
                return opcionSelect;
            }
            return 0;
        }
    }
}
