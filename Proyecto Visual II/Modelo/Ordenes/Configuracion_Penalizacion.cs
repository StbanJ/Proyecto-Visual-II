using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Configuracion_Penalizacion : IDBEntity
    {
        public int Configuracion_PenalizacionID { get; set; }
        public Estado Estado { get; set; }
        public int EstadoID { get; set; }
        public string Descripcion { get; set; }
    }
}
