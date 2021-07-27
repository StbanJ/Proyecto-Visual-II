using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using Modelo.Ordenes;
using Persistencia;

namespace Escenarios
{
    public class Escenario2 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {    
            using (var db = new BodegaContext())
            {
                var est_cancelado = db.Estado
                    .Where(est_cancelado => est_cancelado.Nom_Estado == "Cancelado")
                    .Single();
                Configuracion_Penalizacion pen_cancelado = new()
                {
                    EstadoID = est_cancelado.EstadoID,
                    Descripcion = "Se descontara el 5% del valor Cancelado"
                };
                var est_entregado = db.Estado
                    .Where(est_entregado => est_entregado.Nom_Estado == "Entregado")
                    .Single();
                Configuracion_Penalizacion pen_Entregado = new()
                {
                    EstadoID = est_entregado.EstadoID,
                    Descripcion = "No existe Penalizacion Alguna"
                };
                var est_enproceso = db.Estado
                    .Where(est_enproceso => est_enproceso.Nom_Estado == "En Proceso")
                    .Single();
                Configuracion_Penalizacion pen_EnProceso = new()
                {
                    EstadoID = est_enproceso.EstadoID,
                    Descripcion = "No existe Penalizacion Alguna"
                };

                List<Configuracion_Penalizacion> lstConfiguracionPen = new()
                {
                    pen_cancelado,
                    pen_EnProceso,
                    pen_Entregado
                };
                datos.Add(ListaTipo.Configuracion_Penalizacion, lstConfiguracionPen);

                var bodega1 = db.Ciudad
                  .Where(bodega1 => bodega1.Ciudad_Nom == "Tena")
                  .Single();
                Bodega Bodega1 = new()
                {
                    CiudadID = bodega1.CiudadID,
                    nom_Bodega = "Colosal"
                };

                var bodega2 = db.Ciudad
                  .Where(bodega2 => bodega2.Ciudad_Nom == "Loja")
                  .Single();
                Bodega Bodega2 = new()
                {
                    CiudadID = bodega2.CiudadID,
                    nom_Bodega = "Corp Girasol"
                };
                var bodega3 = db.Ciudad
                  .Where(bodega3 => bodega3.Ciudad_Nom == "Ibarra")
                  .Single();
                Bodega Bodega3 = new()
                {
                    CiudadID = bodega3.CiudadID,
                    nom_Bodega = "JumboCenter"
                };
                var bodega4 = db.Ciudad
                  .Where(bodega4 => bodega4.Ciudad_Nom == "Cuenca")
                  .Single();
                Bodega Bodega4 = new()
                {
                    CiudadID = bodega4.CiudadID,
                    nom_Bodega = "Corazon"
                };
                var bodega5 = db.Ciudad
                  .Where(bodega5 => bodega5.Ciudad_Nom == "Guayaquil")
                  .Single();
                Bodega Bodega5 = new()
                {
                    CiudadID = bodega5.CiudadID,
                    nom_Bodega = "King"
                };
                var bodega6 = db.Ciudad
                  .Where(bodega6 => bodega6.Ciudad_Nom == "Quito")
                  .Single();
                Bodega Bodega6 = new()
                {
                    CiudadID = bodega6.CiudadID,
                    nom_Bodega = "Corporacion la Favorita"
                };
                List<Bodega> lstBodegas = new()
                {
                    Bodega1,
                    Bodega2,
                    Bodega3,
                    Bodega4,
                    Bodega5,
                    Bodega6
                };
                datos.Add(ListaTipo.Bodega, lstBodegas);

                
                    
                Producto Producto1 = new()
                {
                    Nom_Producto = "Papel Jumbo Familia",
                    Stock = 600,
                    BodegaID = 1,
                    Precio_Unit = 20.00
                };
                Producto Producto2 = new()
                {
                    Nom_Producto = "Aceite Girasol",
                    Stock = 1000,
                    BodegaID = 2,
                    Precio_Unit = 2.50
                };
                Producto Producto3 = new()
                {
                    Nom_Producto = "Medias Rolland",
                    Stock = 6000,
                    BodegaID = 3,
                    Precio_Unit = 3.50

                };
                Producto Producto4 = new()
                {
                    Nom_Producto = "Sillas",
                    Stock = 1000,
                    BodegaID = 4,
                    Precio_Unit = 10.00
                };
                Producto Producto5 = new()
                {
                    Nom_Producto = "Fundas XXL",
                    Stock = 5000,
                    BodegaID = 5,
                    Precio_Unit = 2.50
                };
                Producto Producto6 = new()
                {
                    Nom_Producto = "Soportes TV",
                    Stock = 10000,
                    BodegaID = 6,
                    Precio_Unit = 15.00
                };
                List<Producto> lstProductos = new()
                {
                    Producto1,
                    Producto2,
                    Producto3,
                    Producto4,
                    Producto5,
                    Producto6
                };
                datos.Add(ListaTipo.Producto, lstProductos);
                return datos;
            }
        }
    }
}
