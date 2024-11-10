using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace com.cake_lovers.www.Migrations
{
    public partial class acrecentadocategoriaaoproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cagegoria",
                table: "Produtos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoEntrega",
                table: "Pedidos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SituacaoPagamento",
                table: "Pedidos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cagegoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "SituacaoEntrega",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "SituacaoPagamento",
                table: "Pedidos");
        }
    }
}
