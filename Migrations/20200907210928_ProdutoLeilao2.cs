using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCarWeb.Migrations
{
    public partial class ProdutoLeilao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leilao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    TaxaAvaliacao = table.Column<double>(nullable: false),
                    TaxaVenda = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    VlAnunciado = table.Column<double>(nullable: false),
                    VlPago = table.Column<double>(nullable: false),
                    VlVendido = table.Column<double>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Localizacao = table.Column<string>(nullable: true),
                    Anuncio = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Vendedor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leiloeiro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    TaxaAvaliacaoPadrao = table.Column<double>(nullable: false),
                    TaxaVendaPadrao = table.Column<double>(nullable: false),
                    LeilaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leiloeiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leiloeiro_Leilao_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leilao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeilaoProduto",
                columns: table => new
                {
                    ProdutoId = table.Column<string>(nullable: false),
                    LeilaoId = table.Column<int>(nullable: false),
                    Lote = table.Column<int>(nullable: false),
                    VlAvalicao = table.Column<double>(nullable: false),
                    VlCondicional = table.Column<double>(nullable: false),
                    VlVenda = table.Column<double>(nullable: false),
                    ProdutoId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeilaoProduto", x => new { x.ProdutoId, x.LeilaoId });
                    table.ForeignKey(
                        name: "FK_LeilaoProduto_Leilao_LeilaoId",
                        column: x => x.LeilaoId,
                        principalTable: "Leilao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeilaoProduto_Produto_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeilaoProduto_LeilaoId",
                table: "LeilaoProduto",
                column: "LeilaoId");

            migrationBuilder.CreateIndex(
                name: "IX_LeilaoProduto_ProdutoId1",
                table: "LeilaoProduto",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Leiloeiro_LeilaoId",
                table: "Leiloeiro",
                column: "LeilaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeilaoProduto");

            migrationBuilder.DropTable(
                name: "Leiloeiro");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Leilao");
        }
    }
}
