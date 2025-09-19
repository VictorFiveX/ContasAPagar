using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContasAPagar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Criando_tabela_contas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    id_conta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_conta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor_original = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data_vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_pagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor_corrigido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dias_atraso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.id_conta);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
