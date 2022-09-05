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
        public void DrawHeadAndBody(string titulo, List<object> lista)
        {
            int len = MaxLength(titulo, lista);
            DrawHead(titulo, len);
            DrawBody(lista, len);
            WriteLine($"*{XChar("=", (len * 3) - 3)}*");
        }

        private int MaxLength(string titulo, List<object> lista)
        {
            int lenTitulo = titulo.Length;
            int lenMaxItemList = lista.Max().ToString().Length;
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

        public void DrawBody(List<Object> lista, int spacio)
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
