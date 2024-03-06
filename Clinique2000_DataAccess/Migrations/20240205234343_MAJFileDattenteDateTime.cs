using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJFileDattenteDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 5, 23, 43, 42, 996, DateTimeKind.Local).AddTicks(5412), new DateTime(2024, 2, 5, 15, 43, 42, 996, DateTimeKind.Local).AddTicks(5376), new DateTime(2024, 2, 5, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5417), new DateTime(2024, 2, 6, 15, 43, 42, 996, DateTimeKind.Local).AddTicks(5414), new DateTime(2024, 2, 6, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5416) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
