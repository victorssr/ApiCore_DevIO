using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSDev.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CASA",
                columns: table => new
                {
                    ID_CASA = table.Column<Guid>(nullable: false),
                    VLR_TOTAL_DESPESA = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CASA", x => x.ID_CASA);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<Guid>(nullable: false),
                    ID_CASA = table.Column<Guid>(nullable: false),
                    DSC_LOGRADOURO = table.Column<string>(maxLength: 200, nullable: false),
                    NUM_ENDERECO = table.Column<int>(nullable: false),
                    DSC_COMPLEMENTO = table.Column<string>(maxLength: 10, nullable: true),
                    NOM_BAIRRO = table.Column<string>(maxLength: 200, nullable: false),
                    NOM_CIDADE = table.Column<string>(maxLength: 200, nullable: false),
                    SGL_ESTADO = table.Column<string>(maxLength: 2, nullable: false),
                    COD_CEP = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO_CASA_ID_CASA",
                        column: x => x.ID_CASA,
                        principalTable: "CASA",
                        principalColumn: "ID_CASA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MORADOR",
                columns: table => new
                {
                    ID_MORADOR = table.Column<Guid>(nullable: false),
                    ID_CASA = table.Column<Guid>(nullable: false),
                    NOM_MORADOR = table.Column<string>(maxLength: 200, nullable: false),
                    VLR_RECEITA_MENSAL = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: true),
                    VLR_CONTRIBUICAO = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MORADOR", x => x.ID_MORADOR);
                    table.ForeignKey(
                        name: "FK_MORADOR_CASA_ID_CASA",
                        column: x => x.ID_CASA,
                        principalTable: "CASA",
                        principalColumn: "ID_CASA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESPESA_INDIVIDUAL",
                columns: table => new
                {
                    ID_DESPESA_INDIVIDUAL = table.Column<Guid>(nullable: false),
                    ID_MORADOR = table.Column<Guid>(nullable: false),
                    DSC_DESPESA = table.Column<string>(maxLength: 200, nullable: false),
                    VLR_DESPESA = table.Column<decimal>(type: "DECIMAL(9, 2)", nullable: false),
                    DAT_VENCIMENTO = table.Column<DateTime>(nullable: false),
                    DAT_PAGAMENTO = table.Column<DateTime>(nullable: true),
                    NUM_MES = table.Column<int>(nullable: false),
                    NUM_ANO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESPESA_INDIVIDUAL", x => x.ID_DESPESA_INDIVIDUAL);
                    table.ForeignKey(
                        name: "FK_DESPESA_INDIVIDUAL_MORADOR_ID_MORADOR",
                        column: x => x.ID_MORADOR,
                        principalTable: "MORADOR",
                        principalColumn: "ID_MORADOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DESPESA_INDIVIDUAL_ID_MORADOR",
                table: "DESPESA_INDIVIDUAL",
                column: "ID_MORADOR");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_ID_CASA",
                table: "ENDERECO",
                column: "ID_CASA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MORADOR_ID_CASA",
                table: "MORADOR",
                column: "ID_CASA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DESPESA_INDIVIDUAL");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "MORADOR");

            migrationBuilder.DropTable(
                name: "CASA");
        }
    }
}
