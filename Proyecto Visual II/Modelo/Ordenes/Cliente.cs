using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Cliente :IDBEntity
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Orden> Ordenes { get; set; }
       
    }
}
