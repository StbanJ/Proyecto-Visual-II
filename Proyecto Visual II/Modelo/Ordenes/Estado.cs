using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Estado : IDBEntity
    {
        public int EstadoID { get; set; }
        public string Nom_Estado { get; set; }
        
        public List<Orden> Orden { get; set;  }
        public Configuracion_Penalizacion Configuracion_Penalizacion { get; set; }
    }
}
