using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class CreateInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "solicitacaoCompras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioSolicitante = table.Column<string>(nullable: true),
                    NomeFornecedor = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    CondicaoPagamento = table.Column<int>(nullable: false),
                    TotalGeral = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitacaoCompras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    SolicitacaoCompraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_solicitacaoCompras_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "solicitacaoCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("a13d8166-c70e-49db-b710-18242bd014a5"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_items_ProdutoId",
                table: "items",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_items_SolicitacaoCompraId",
                table: "items",
                column: "SolicitacaoCompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "solicitacaoCompras");
        }
    }
}
