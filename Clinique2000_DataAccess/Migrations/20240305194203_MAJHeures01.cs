using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJHeures01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 5, 19, 42, 3, 557, DateTimeKind.Local).AddTicks(464), new DateTime(2024, 3, 5, 11, 42, 3, 557, DateTimeKind.Local).AddTicks(424), new DateTime(2024, 3, 5, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(462) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 6, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(469), new DateTime(2024, 3, 6, 11, 42, 3, 557, DateTimeKind.Local).AddTicks(466), new DateTime(2024, 3, 6, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 5, 19, 42, 3, 557, DateTimeKind.Local).AddTicks(474), new DateTime(2024, 3, 5, 11, 42, 3, 557, DateTimeKind.Local).AddTicks(472), new DateTime(2024, 3, 5, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(473) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 6, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(479), new DateTime(2024, 3, 6, 11, 42, 3, 557, DateTimeKind.Local).AddTicks(476), new DateTime(2024, 3, 6, 14, 42, 3, 557, DateTimeKind.Local).AddTicks(477) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 4, 20, 10, 16, 920, DateTimeKind.Local).AddTicks(2641), new DateTime(2024, 3, 4, 12, 10, 16, 920, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 3, 4, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2639) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 5, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2645), new DateTime(2024, 3, 5, 12, 10, 16, 920, DateTimeKind.Local).AddTicks(2642), new DateTime(2024, 3, 5, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 4, 20, 10, 16, 920, DateTimeKind.Local).AddTicks(2649), new DateTime(2024, 3, 4, 12, 10, 16, 920, DateTimeKind.Local).AddTicks(2647), new DateTime(2024, 3, 4, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2648) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 3, 5, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2653), new DateTime(2024, 3, 5, 12, 10, 16, 920, DateTimeKind.Local).AddTicks(2651), new DateTime(2024, 3, 5, 15, 10, 16, 920, DateTimeKind.Local).AddTicks(2652) });
        }
    }
}
