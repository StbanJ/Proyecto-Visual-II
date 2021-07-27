using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Ciudad : IDBEntity
    {
        public int CiudadID { get; set; }
        public string Ciudad_Nom { get; set; }
        public Bodega Bodega { get; set; }
    }
}
