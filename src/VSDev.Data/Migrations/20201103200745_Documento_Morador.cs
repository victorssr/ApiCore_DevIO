using Microsoft.EntityFrameworkCore.Migrations;

namespace VSDev.Data.Migrations
{
    public partial class Documento_Morador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DSC_DOCUMENTO",
                table: "MORADOR",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "COD_TIPO_DOCUMENTO",
                table: "MORADOR",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSC_DOCUMENTO",
                table: "MORADOR");

            migrationBuilder.DropColumn(
                name: "COD_TIPO_DOCUMENTO",
                table: "MORADOR");
        }
    }
}
