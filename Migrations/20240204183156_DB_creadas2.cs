using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relaciones.Migrations
{
    /// <inheritdoc />
    public partial class DB_creadas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor_ProveedorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedores_ProveedorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor_ProveedorId",
                table: "Productos",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
