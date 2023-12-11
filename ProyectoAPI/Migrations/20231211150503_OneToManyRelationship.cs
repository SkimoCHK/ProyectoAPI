using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAPI.Migrations
{
    public partial class OneToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Instalacion_InstalacionID",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Profesores_ProfesorID",
                table: "Reserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Instalacion_InstalacionID",
                table: "Reserva",
                column: "InstalacionID",
                principalTable: "Instalacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Profesores_ProfesorID",
                table: "Reserva",
                column: "ProfesorID",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Instalacion_InstalacionID",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Profesores_ProfesorID",
                table: "Reserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Instalacion_InstalacionID",
                table: "Reserva",
                column: "InstalacionID",
                principalTable: "Instalacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Profesores_ProfesorID",
                table: "Reserva",
                column: "ProfesorID",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
