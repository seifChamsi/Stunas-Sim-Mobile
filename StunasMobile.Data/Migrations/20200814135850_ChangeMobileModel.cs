using Microsoft.EntityFrameworkCore.Migrations;

namespace StunasMobile.Data.Migrations
{
    public partial class ChangeMobileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sociéte",
                table: "mobile",
                newName: "societe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "societe",
                table: "mobile",
                newName: "sociéte");
        }
    }
}
