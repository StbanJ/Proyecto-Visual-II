using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class BodegaConfig
    {
        static public string PersistenciaDestino;
        static public string connectionString;
        static public bool modoVirtual;
        static public string DBMemory;

        static BodegaConfig()
        {

            //Lectura de los parámetros del sistema
            PersistenciaDestino = ConfigurationManager.AppSettings["PersistenciaDestino"].ToString();
            connectionString = ConfigurationManager.ConnectionStrings[PersistenciaDestino].ToString();
            //Debug
            Console.WriteLine(PersistenciaDestino + " " + connectionString);
        }


        static public DbContextOptions<BodegaContext> ContextOptions()
        {

            DbContextOptions<BodegaContext> opciones = null;
            modoVirtual = true;
            switch (PersistenciaDestino)
            {
                case "SQLServerEscuela":
                    opciones = new DbContextOptionsBuilder<BodegaContext>()
                        .UseSqlServer(connectionString)
                        .Options;
                    break;
                case "PostgresEscuela":
                    opciones = new DbContextOptionsBuilder<BodegaContext>()
                        .UseNpgsql(connectionString)
                        .Options;
                    break;
                case "memoriaEscuela":
                    if (modoVirtual)
                    {
                        opciones = new DbContextOptionsBuilder<BodegaContext>()
                            .UseInMemoryDatabase(connectionString)
                            .Options;
                    }
                    break;
                default:
                    break;
            }
            return opciones;
        }
    }
}
