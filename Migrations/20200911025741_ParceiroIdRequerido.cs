using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestCarWeb.Migrations
{
    public partial class ParceiroIdRequerido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_AspNetUsers_ParceiroId",
                table: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "ParceiroId",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_AspNetUsers_ParceiroId",
                table: "Produto",
                column: "ParceiroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_AspNetUsers_ParceiroId",
                table: "Produto");

            migrationBuilder.AlterColumn<string>(
                name: "ParceiroId",
                table: "Produto",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_AspNetUsers_ParceiroId",
                table: "Produto",
                column: "ParceiroId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
