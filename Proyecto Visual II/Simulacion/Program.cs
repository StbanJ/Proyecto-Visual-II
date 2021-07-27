using System;
using System.Linq;
using Escenarios;
using Persistencia;
using Procesos;

namespace Simulacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var Escenario = new Escenario1();
            var escenarioControl = new EscenarioControl();
            escenarioControl.Grabar(Escenario);

            var Escenario2 = new Escenario2();
            escenarioControl.Grabar2(Escenario2);

            Proceso1 Proceso = new Proceso1();
            Proceso.ingresarOrden(new DateTime (2021, 7, 26), 100,  "ViveresAntonhy", 3, "Papel Jumbo Familia", "Colosal",      "Ciudad de Machala Av.Giron N65" );
            Proceso.ingresarOrden(new DateTime (2021, 7, 27), 500,  "Wonderlan",      3, "Aceite Girasol",      "Corp Girasol", "Ciudad de Quito AV.Diez de Agosto y Colon N657");
            Proceso.ingresarOrden(new DateTime (2021, 7, 28), 1000, "Sucasa",         3, "Medias Rolland",      "JumboCenter",  "Ciudad del ORO calle marvella N89");
            Proceso.ingresarOrden(new DateTime (2021, 8, 1), 550,   "Sigma",          3, "Sillas",              "Corazon",      "Ciudad de Ibarra Calle Garcia Moreno y Julian Alvarez");

            Proceso.actualizacionEstado(new DateTime(2021, 7, 26), "ViveresAntonhy", "Cancelado");

            Proceso.consultaPenalizacion(new DateTime(2021, 7, 26), "ViveresAntonhy");

        }
    }
}
