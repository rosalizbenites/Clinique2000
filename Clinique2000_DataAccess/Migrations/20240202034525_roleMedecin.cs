using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class roleMedecin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 3, 45, 25, 420, DateTimeKind.Local).AddTicks(7903), new DateTime(2024, 2, 1, 19, 45, 25, 420, DateTimeKind.Local).AddTicks(7861), new DateTime(2024, 2, 1, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7909), new DateTime(2024, 2, 2, 19, 45, 25, 420, DateTimeKind.Local).AddTicks(7905), new DateTime(2024, 2, 2, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7907) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
