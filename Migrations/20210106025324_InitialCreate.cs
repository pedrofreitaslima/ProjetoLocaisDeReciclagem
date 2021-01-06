using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoLocaisDeReciclagem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocaisReciclagem",
                columns: table => new
                {
                    LocalReciclagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NumeroEndereco = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Capacidade = table.Column<double>(type: "float", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaisReciclagem", x => x.LocalReciclagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocaisReciclagem");
        }
    }
}
