using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModDatesFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 1, 18, 50, 475, DateTimeKind.Local).AddTicks(7519), new DateTime(2024, 2, 6, 17, 18, 50, 475, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 2, 6, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7524), new DateTime(2024, 2, 7, 17, 18, 50, 475, DateTimeKind.Local).AddTicks(7521), new DateTime(2024, 2, 7, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7523) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
