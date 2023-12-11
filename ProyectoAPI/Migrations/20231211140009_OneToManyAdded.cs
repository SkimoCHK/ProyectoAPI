using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAPI.Migrations
{
    public partial class OneToManyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalacion_Edificio_EdificioID",
                table: "Instalacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacion_Edificio_EdificioID",
                table: "Instalacion",
                column: "EdificioID",
                principalTable: "Edificio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instalacion_Edificio_EdificioID",
                table: "Instalacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Instalacion_Edificio_EdificioID",
                table: "Instalacion",
                column: "EdificioID",
                principalTable: "Edificio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
