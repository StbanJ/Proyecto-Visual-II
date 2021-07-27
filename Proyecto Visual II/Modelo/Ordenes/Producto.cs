using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Producto : IDBEntity
    {
        public int ProductoID { get; set; }
        public string Nom_Producto { get; set; }
        public int Stock { get; set; }
        public Bodega Bodega { get; set; }
        public int BodegaID { get; set; }
        public double Precio_Unit { get; set; }
        public Orden Orden { get; set; }
    }
}
