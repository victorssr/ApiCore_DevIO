using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSDev.Data.Migrations
{
    public partial class Victor_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DAT_NASCIMENTO",
                table: "MORADOR",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NOM_FOTO",
                table: "MORADOR",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "COD_TIPO_MORADOR",
                table: "MORADOR",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DAT_NASCIMENTO",
                table: "MORADOR");

            migrationBuilder.DropColumn(
                name: "NOM_FOTO",
                table: "MORADOR");

            migrationBuilder.DropColumn(
                name: "COD_TIPO_MORADOR",
                table: "MORADOR");
        }
    }
}
