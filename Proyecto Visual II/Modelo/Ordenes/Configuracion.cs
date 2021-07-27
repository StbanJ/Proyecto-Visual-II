using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Ordenes
{
    public class Configuracion : IDBEntity
    {
        public int ConfiguracionID { get; set; }
        public string Fecha_min_entrega { get; set; }
    }
}
