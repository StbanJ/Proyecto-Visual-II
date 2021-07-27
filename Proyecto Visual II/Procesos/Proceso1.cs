using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo.Ordenes;
using Persistencia;

namespace Procesos
{
    public class Proceso1
    {
        public void ingresarOrden(DateTime fecha_de_Solitud, int cantidad, String NombreCliente, int NombreEstado, String NomProducto, String NomBodega, String Destino) 
        {
            using (var db = new BodegaContext()) 
            {
                var cliente = db.Cliente
                    .Single(cli => cli.Nombre == NombreCliente);
                var estado = db.Estado
                    .Single(est => est.EstadoID == NombreEstado);
                var producto = db.Producto
                    .Single(pro => pro.Nom_Producto == NomProducto);
                var bodega = db.Bodega
                    .Single(bod => bod.nom_Bodega == NomBodega);

                Orden ingresarOrdenes = new()
                {
                    Fecha_de_Solicitud = fecha_de_Solitud,
                    Cantidad = cantidad,
                    ClienteID = cliente.ClienteID,
                    Destino = Destino,
                    EstadoID = estado.EstadoID,
                    Fecha_de_Despacho = calcularFechaDespacho(fecha_de_Solitud),
                    ProductoID = producto.ProductoID
                };
                try
                {
                    db.Add(ingresarOrdenes);
                    db.SaveChanges();

                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("\n\tOrden Ingresada");
                    Console.WriteLine("Fecha_de_Solicitud:\t" +fecha_de_Solitud);
                    Console.WriteLine("Cantidad:\t" + cantidad);
                    Console.WriteLine("ClienteID:\t" + NombreCliente);
                    Console.WriteLine("Destino:\t" + Destino);
                    Console.WriteLine("EstadoID\t" + NombreEstado);
                    Console.WriteLine("Fecha_de_Despacho:\t" + calcularFechaDespacho(fecha_de_Solitud));
                    Console.WriteLine("ProductoID:\t" + NomProducto);



                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
            }
        }

        public DateTime calcularFechaDespacho(DateTime fecha_de_Solitud)
        {
            int anio = fecha_de_Solitud.Year;
            int mes = fecha_de_Solitud.Month;
            int dia = fecha_de_Solitud.Day + 3;

            return new DateTime (anio,mes,dia);
        }
        public void consultaPenalizacion(DateTime fecha_de_solicitud, string NomCliente) 
        {

            using (var db = new BodegaContext()) {

                var orden = db.Orden
                    .Include(ord => ord.Cliente)
                    .Single(ord => ord.Cliente.Nombre == NomCliente && ord.Fecha_de_Solicitud == fecha_de_solicitud);

                var pendesc = db.Configuracion_Penalizacions
                    .Single(con => con.Descripcion == "Se descontara el 5% del valor Cancelado");
                var penning = db.Configuracion_Penalizacions
                   .Single(con => con.Descripcion == "No existe Penalizacion Alguna" && con.Configuracion_PenalizacionID == 2);

                if (orden.EstadoID == pendesc.EstadoID)
                {
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("\n\tNOTIFICACION DE PENALIZACION");
                    Console.WriteLine("Atencion:\t" + pendesc.Descripcion);
                }
                else 
                {
                    Console.WriteLine(penning.Descripcion);
                }
            }

        }

        public void actualizacionEstado(DateTime fecha_de_solicitud, string NomCliente, string nuevoEstado)
        {

            using (var db = new BodegaContext())
            {

                var orden = db.Orden
                    .Include(ord => ord.Cliente)
                    .Single(ord => ord.Cliente.Nombre == NomCliente && ord.Fecha_de_Solicitud == fecha_de_solicitud);

                var estado = db.Estado
                     .Single(est => est.Nom_Estado == nuevoEstado);


               
                try
                {
                    orden.EstadoID = estado.EstadoID;
                    db.SaveChanges();

                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("\n\tActualizacion de Estado");
                    Console.WriteLine("Fecha_de_Solicitud:\t" + fecha_de_solicitud);
                    Console.WriteLine("ClienteID:\t" + NomCliente);
                    Console.WriteLine("EstadoID:\t" + estado.EstadoID);
                    Console.WriteLine("El estado fue actualizado Exitosamente!");

                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
            }

        }

    }
}
