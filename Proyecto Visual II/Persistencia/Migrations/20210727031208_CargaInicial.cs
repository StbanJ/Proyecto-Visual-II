using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class CargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    CiudadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ciudad_Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.CiudadID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    ConfiguracionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_min_entrega = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.ConfiguracionID);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    BodegaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_Bodega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.BodegaID);
                    table.ForeignKey(
                        name: "FK_Bodega_Ciudad_CiudadID",
                        column: x => x.CiudadID,
                        principalTable: "Ciudad",
                        principalColumn: "CiudadID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configuracion_Penalizacions",
                columns: table => new
                {
                    Configuracion_PenalizacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion_Penalizacions", x => x.Configuracion_PenalizacionID);
                    table.ForeignKey(
                        name: "FK_Configuracion_Penalizacions_Estado_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Producto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    BodegaID = table.Column<int>(type: "int", nullable: false),
                    Precio_Unit = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Producto_Bodega_BodegaID",
                        column: x => x.BodegaID,
                        principalTable: "Bodega",
                        principalColumn: "BodegaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_de_Solicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoID = table.Column<int>(type: "int", nullable: false),
                    Fecha_de_Despacho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Estado_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estado",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Producto_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Producto",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_CiudadID",
                table: "Bodega",
                column: "CiudadID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configuracion_Penalizacions_EstadoID",
                table: "Configuracion_Penalizacions",
                column: "EstadoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orden_ClienteID",
                table: "Orden",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_EstadoID",
                table: "Orden",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_ProductoID",
                table: "Orden",
                column: "ProductoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_BodegaID",
                table: "Producto",
                column: "BodegaID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "Configuracion_Penalizacions");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "Ciudad");
        }
    }
}
