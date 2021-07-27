using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Orden : IDBEntity
    {
        public int OrdenID { get; set; }
        public DateTime Fecha_de_Solicitud { get; set; }
        public int Cantidad { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteID { get; set; }
        public string Destino { get; set; }
        public Estado Estado { get; set; }
        public int EstadoID { get; set; }
        public DateTime Fecha_de_Despacho { get; set; }

        public Producto Producto { get; set; }
        public int ProductoID { get; set; }


    }
}
