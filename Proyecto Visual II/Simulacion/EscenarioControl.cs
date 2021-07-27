using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escenarios;
using Modelo.Ordenes;
using Persistencia;
using static Escenarios.Escenario;

namespace Simulacion
{
    public class EscenarioControl
    {
        public void Grabar(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new BodegaContext())
            {

                //Reiniciamos la Base de datos
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //Insertamos los datos
                db.Cliente.AddRange((List<Cliente>)datos[ListaTipo.Cliente]);
                db.Ciudad.AddRange((List<Ciudad>)datos[ListaTipo.Ciudad]);
                db.Estado.AddRange((List<Estado>)datos[ListaTipo.Estado]);
                db.Configuracion.AddRange((List<Configuracion>)datos[ListaTipo.Configuracion]);



                //Genera la persistencia
                db.SaveChanges();

            }
        }
        public void Grabar2(IEscenario escenario)
        {
            var datos = escenario.carga();
            using (var db = new BodegaContext())
            {

                

                //Insertamos los datos
                db.Configuracion_Penalizacions.AddRange((List<Configuracion_Penalizacion>)datos[ListaTipo.Configuracion_Penalizacion]);
                db.Bodega.AddRange((List<Bodega>)datos[ListaTipo.Bodega]);
                db.Producto.AddRange((List<Producto>)datos[ListaTipo.Producto]);




                //Genera la persistencia
                db.SaveChanges();

            }
        }
    }
}
