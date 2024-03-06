using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class HeureFermeture : Migration
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
                values: new object[] { new DateTime(2024, 2, 2, 3, 44, 3, 202, DateTimeKind.Local).AddTicks(296), new DateTime(2024, 2, 1, 19, 44, 3, 202, DateTimeKind.Local).AddTicks(259), new DateTime(2024, 2, 1, 22, 44, 3, 202, DateTimeKind.Local).AddTicks(294) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 22, 44, 3, 202, DateTimeKind.Local).AddTicks(303), new DateTime(2024, 2, 2, 19, 44, 3, 202, DateTimeKind.Local).AddTicks(300), new DateTime(2024, 2, 2, 22, 44, 3, 202, DateTimeKind.Local).AddTicks(301) });
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
                values: new object[] { new DateTime(2024, 2, 2, 2, 11, 33, 90, DateTimeKind.Local).AddTicks(2094), new DateTime(2024, 2, 1, 18, 11, 33, 90, DateTimeKind.Local).AddTicks(2051), new DateTime(2024, 2, 1, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2099), new DateTime(2024, 2, 2, 18, 11, 33, 90, DateTimeKind.Local).AddTicks(2096), new DateTime(2024, 2, 2, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2098) });
        }
    }
}
