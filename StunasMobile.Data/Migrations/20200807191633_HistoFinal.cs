using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StunasMobile.Data.Migrations
{
    public partial class HistoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historique",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangedColumns = table.Column<List<string>>(type: "text[]", nullable: true),
                    PreviousValues = table.Column<List<string>>(type: "text[]", nullable: true),
                    NewValues = table.Column<List<string>>(type: "text[]", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecordId = table.Column<int>(type: "integer", nullable: false),
                    MobileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historique", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historique_mobile_MobileId",
                        column: x => x.MobileId,
                        principalTable: "mobile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historique_MobileId",
                table: "Historique",
                column: "MobileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historique");

            migrationBuilder.DropTable(
                name: "mobile");
        }
    }
}
