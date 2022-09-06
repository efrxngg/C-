using ConsumoApiSpotify.Entitys;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsumoApiSpotify.Utils
{
    public class Printer
    {
        public void DrawHeadAndBody(string titulo, List<Item> lista, bool popularity = false, bool follows = false)
        {
            int len = MaxLength(titulo, lista);
            DrawHead(titulo, len);
            DrawBody(lista, len, popularity, follows);
            WriteLine($"*{XChar("=", len * 3)}*");
        }
        public void DrawHeadAndBody(string titulo, List<string> lista)
        {
            int len = MaxLength(titulo, lista);
            DrawHead(titulo, len);
            DrawBody(lista, len);

        }
        private int MaxLength(string titulo, List<Item> lista)
        {
            int lenTitulo = titulo.Length;
            int lenMaxItemList = 0;
            try
            {
                lenMaxItemList = lista.Max(x => x.name.Length);

            }catch(Exception ex) { 
                WriteLine("No se encuentrar Resultados con tu busqueda");
                lenMaxItemList = 1; 
            }

            if (lenTitulo > lenMaxItemList)
            {
                return lenTitulo;
            }
            
            return lenMaxItemList;
        }
        private int MaxLength(string titulo, List<string> lista)
        {
            int lenTitulo = titulo.Length;
            int lenMaxItemList = lista.Max(x => x.Length);

            if (lenTitulo > lenMaxItemList)
            {
                return lenTitulo;
            }

            return lenMaxItemList;
        }
        public void DrawHead(string titulo, int spacio)
        {
            int lenTitulo = titulo.Length;
            WriteLine($"*{XChar("=", spacio)}{XChar("=", lenTitulo)}{XChar("=", spacio)}*");
            WriteLine($"*{XChar(" ", spacio)}{titulo}{XChar(" ", spacio)}*");
            WriteLine($"*{XChar("=", spacio)}{XChar("=", lenTitulo)}{XChar("=", spacio)}*");

        }
        public void DrawBody(List<Item> lista, int spacio, bool popularity=false, bool follows=false)
        {
            int lenLista = lista.Count();
            //int lenMaxItemList = lista.Max().ToString().Length;

            for (int item = 0; item < lenLista; item++)
            {
                WriteLine($" {item + 1}.- {lista[item].name}");
                if (popularity)
                {
                    WriteLine($" Popularidad: {lista[item].popularity}%");
                }
                if (follows)
                {
                    WriteLine($" Seguidores: {lista[item].followers.total}");
                }
            }
           

        }
        public void DrawBody(List<string> lista, int spacio)
        {
            int lenLista = lista.Count();
            //int lenMaxItemList = lista.Max().ToString().Length;

            for (int item = 0; item < lenLista; item++)
            {
                WriteLine($" {item + 1}.- {lista[item]}");
            }


        }
        public string XChar(string caracter, int cant)
        {
            return String.Concat(Enumerable.Repeat(caracter, cant));
        }
    }
}
