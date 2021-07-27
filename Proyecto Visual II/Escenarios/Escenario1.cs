
using System.Collections.Generic;

using Modelo;
using Modelo.Ordenes;

namespace Escenarios
{
    public class Escenario1 : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> carga()
        {
            Cliente ViveresAntonhy = new() { Nombre = "ViveresAntonhy", Direccion = "Comite del Pueblo", Telefono = "0989127881" };
            Cliente FullHome       = new() { Nombre = "Full Home", Direccion = "Astudillo", Telefono = "0989128991" };
            Cliente Casita         = new() { Nombre = "Casita", Direccion = "Gabriel Garcia N156", Telefono = "098657489" };
            Cliente Manuelita      = new() { Nombre = "Manuelita", Direccion = "Jose Segovia", Telefono = "0225468789" };
            Cliente TriMercado     = new() { Nombre = "TriMercado", Direccion = "Av. Golpes", Telefono = "0987458749" };
            Cliente CajitaAbasto   = new() { Nombre = "Cajita Abasto", Direccion = "Guillermo N45", Telefono = "097584963" };
            Cliente Sigma          = new() { Nombre = "Sigma", Direccion = "Av. Cipreses y Guadillo", Telefono = "096584967" };
            Cliente Sarita         = new() { Nombre = "Sarita", Direccion = "Girasoles N54", Telefono = "0984568744" };
            Cliente Wonderland     = new() { Nombre = "Wonderlan", Direccion = "Calle Arevalos y Tijuana", Telefono = "0987456589" };
            Cliente Sucasa         = new() { Nombre = "Sucasa", Direccion = "Mario Alvarado", Telefono = "0225658498" };

            List<Cliente> lstClientes = new() { ViveresAntonhy, FullHome, Casita, Manuelita, TriMercado, CajitaAbasto, Sigma, Sarita, Wonderland, Sucasa };
            datos.Add(ListaTipo.Cliente,lstClientes);

            Ciudad Quito     = new() { Ciudad_Nom = "Quito" };
            Ciudad Guayaquil = new() { Ciudad_Nom = "Guayaquil" };
            Ciudad Cuenca    = new() { Ciudad_Nom = "Cuenca" };
            Ciudad Ibarra    = new() { Ciudad_Nom = "Ibarra" };
            Ciudad Loja      = new() { Ciudad_Nom = "Loja" };
            Ciudad Tena      = new() { Ciudad_Nom = "Tena" };

            List<Ciudad> lstCiudad = new() { Quito, Guayaquil, Cuenca, Ibarra, Loja, Tena };
            datos.Add(ListaTipo.Ciudad, lstCiudad);

            Estado Entregado = new() { Nom_Estado = "Entregado" };
            Estado EnProeso = new() { Nom_Estado = "En Proceso" };
            Estado Cancelado = new() { Nom_Estado = "Cancelado" };

            List<Estado> lstEstado = new() { Entregado, EnProeso, Cancelado };
            datos.Add(ListaTipo.Estado, lstEstado);

            Configuracion fechaminentrega = new() { Fecha_min_entrega = "3 dias" };
            List<Configuracion> lstConfiguracion = new() { fechaminentrega };
            datos.Add(ListaTipo.Configuracion, lstConfiguracion);

            return datos;
        }
        }
}
