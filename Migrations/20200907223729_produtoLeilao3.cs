using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCarWeb.Migrations
{
    public partial class produtoLeilao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeilaoProduto_Produto_ProdutoId1",
                table: "LeilaoProduto");

            migrationBuilder.DropIndex(
                name: "IX_LeilaoProduto_ProdutoId1",
                table: "LeilaoProduto");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "LeilaoProduto");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "LeilaoProduto",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_LeilaoProduto_Produto_ProdutoId",
                table: "LeilaoProduto",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeilaoProduto_Produto_ProdutoId",
                table: "LeilaoProduto");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoId",
                table: "LeilaoProduto",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "LeilaoProduto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeilaoProduto_ProdutoId1",
                table: "LeilaoProduto",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LeilaoProduto_Produto_ProdutoId1",
                table: "LeilaoProduto",
                column: "ProdutoId1",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
