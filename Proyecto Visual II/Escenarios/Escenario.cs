
using System.Collections.Generic;

using Modelo;

namespace Escenarios
{
     public class Escenario
    {
        public enum ListaTipo
        {
            Bodega, Ciudad, Cliente, Configuracion, Configuracion_Penalizacion, Estado, Orden, Producto
        };

        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;

        public Escenario() 
        {
            datos = new();
        }
    }
}
