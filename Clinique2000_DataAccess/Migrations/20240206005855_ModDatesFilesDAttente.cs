using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModDatesFilesDAttente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 0, 58, 54, 815, DateTimeKind.Local).AddTicks(7808), new DateTime(2024, 2, 5, 16, 58, 54, 815, DateTimeKind.Local).AddTicks(7771), new DateTime(2024, 2, 5, 19, 58, 54, 815, DateTimeKind.Local).AddTicks(7806) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 19, 58, 54, 815, DateTimeKind.Local).AddTicks(7813), new DateTime(2024, 2, 6, 16, 58, 54, 815, DateTimeKind.Local).AddTicks(7810), new DateTime(2024, 2, 6, 19, 58, 54, 815, DateTimeKind.Local).AddTicks(7811) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 2, 59, 58, 882, DateTimeKind.Local).AddTicks(9562), new DateTime(2024, 2, 1, 18, 59, 58, 882, DateTimeKind.Local).AddTicks(9526), new DateTime(2024, 2, 1, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9568), new DateTime(2024, 2, 2, 18, 59, 58, 882, DateTimeKind.Local).AddTicks(9565), new DateTime(2024, 2, 2, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9567) });
        }
    }
}
