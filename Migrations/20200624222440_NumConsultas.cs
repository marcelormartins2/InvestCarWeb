using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCarWeb.Migrations
{
    public partial class NumConsultas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumConsultas",
                table: "Veiculo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumConsultas",
                table: "Veiculo");
        }
    }
}
