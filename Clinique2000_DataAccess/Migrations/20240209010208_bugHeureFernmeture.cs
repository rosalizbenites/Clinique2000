using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class bugHeureFernmeture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HeureFermeture",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 1, 2, 8, 297, DateTimeKind.Local).AddTicks(7125), new DateTime(2024, 2, 8, 17, 2, 8, 297, DateTimeKind.Local).AddTicks(7079), new DateTime(2024, 2, 8, 20, 2, 8, 297, DateTimeKind.Local).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 20, 2, 8, 297, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 2, 9, 17, 2, 8, 297, DateTimeKind.Local).AddTicks(7127), new DateTime(2024, 2, 9, 20, 2, 8, 297, DateTimeKind.Local).AddTicks(7129) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeureFermeture",
                table: "Cliniques");

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 23, 41, 50, 967, DateTimeKind.Local).AddTicks(1678), new DateTime(2024, 2, 6, 15, 41, 50, 967, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 2, 6, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1683), new DateTime(2024, 2, 7, 15, 41, 50, 967, DateTimeKind.Local).AddTicks(1680), new DateTime(2024, 2, 7, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1681) });
        }
    }
}
