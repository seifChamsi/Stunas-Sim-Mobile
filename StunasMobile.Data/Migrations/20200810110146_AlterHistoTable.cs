using Microsoft.EntityFrameworkCore.Migrations;

namespace StunasMobile.Data.Migrations
{
    public partial class AlterHistoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historique_mobile_MobileId",
                table: "Historique");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Historique");

            migrationBuilder.AlterColumn<int>(
                name: "MobileId",
                table: "Historique",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historique_mobile_MobileId",
                table: "Historique",
                column: "MobileId",
                principalTable: "mobile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historique_mobile_MobileId",
                table: "Historique");

            migrationBuilder.AlterColumn<int>(
                name: "MobileId",
                table: "Historique",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Historique",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Historique_mobile_MobileId",
                table: "Historique",
                column: "MobileId",
                principalTable: "mobile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
