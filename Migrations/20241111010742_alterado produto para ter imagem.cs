using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.cake_lovers.www.Migrations
{
    public partial class alteradoprodutoparaterimagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClientId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "CaminhoFoto",
                table: "Produtos",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Cagegoria",
                table: "Produtos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Enderecos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_ClientId",
                table: "Enderecos",
                newName: "IX_Enderecos_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Produtos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dados = table.Column<byte[]>(type: "longblob", nullable: false),
                    ContentType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_ProdutoId",
                table: "Imagens",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Produtos",
                newName: "CaminhoFoto");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "Cagegoria");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Enderecos",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                newName: "IX_Enderecos_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClientId",
                table: "Enderecos",
                column: "ClientId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
