using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCarWeb.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlVenda",
                table: "LeilaoProduto");

            migrationBuilder.AlterColumn<double>(
                name: "VlPago",
                table: "LeilaoProduto",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "VlCondicional",
                table: "LeilaoProduto",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<string>(
                name: "Lote",
                table: "LeilaoProduto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "VlLance",
                table: "LeilaoProduto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlLance",
                table: "LeilaoProduto");

            migrationBuilder.AlterColumn<double>(
                name: "VlPago",
                table: "LeilaoProduto",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "VlCondicional",
                table: "LeilaoProduto",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Lote",
                table: "LeilaoProduto",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VlVenda",
                table: "LeilaoProduto",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
