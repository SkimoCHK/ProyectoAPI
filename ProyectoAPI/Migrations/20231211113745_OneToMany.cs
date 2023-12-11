using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAPI.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_Carrera_CarreraId",
                table: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor");

            migrationBuilder.RenameTable(
                name: "Profesor",
                newName: "Profesores");

            migrationBuilder.RenameIndex(
                name: "IX_Profesor_CarreraId",
                table: "Profesores",
                newName: "IX_Profesores_CarreraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesores_Carrera_CarreraId",
                table: "Profesores",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "IDCarrera",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesores_Carrera_CarreraId",
                table: "Profesores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profesores",
                table: "Profesores");

            migrationBuilder.RenameTable(
                name: "Profesores",
                newName: "Profesor");

            migrationBuilder.RenameIndex(
                name: "IX_Profesores_CarreraId",
                table: "Profesor",
                newName: "IX_Profesor_CarreraId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profesor",
                table: "Profesor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_Carrera_CarreraId",
                table: "Profesor",
                column: "CarreraId",
                principalTable: "Carrera",
                principalColumn: "IDCarrera",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
