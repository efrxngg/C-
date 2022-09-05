using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Introduccion.Entidades;

namespace Introduccion.App
{
    public class Reportador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;


        public Reportador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEscuela)
        {
            if (dicObjEscuela == null)
            {
                throw new ArgumentNullException(nameof(dicObjEscuela));
            }
        }

        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            

            return lista.Cast<Escuela>();
        }

    }
}
