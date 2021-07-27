using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Bodega : IDBEntity
    {
        public int BodegaID { get; set; }
        public string nom_Bodega { get; set; }
        public Ciudad Ciudad { get; set; }
        public int CiudadID { get; set; }
        public Producto Producto { get; set; }
        
    }
}
