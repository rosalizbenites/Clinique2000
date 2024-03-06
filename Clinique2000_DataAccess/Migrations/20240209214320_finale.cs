using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class finale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 21, 43, 20, 30, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 2, 9, 13, 43, 20, 30, DateTimeKind.Local).AddTicks(2591), new DateTime(2024, 2, 9, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2628) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2637), new DateTime(2024, 2, 10, 13, 43, 20, 30, DateTimeKind.Local).AddTicks(2634), new DateTime(2024, 2, 10, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 21, 43, 20, 30, DateTimeKind.Local).AddTicks(2643), new DateTime(2024, 2, 9, 13, 43, 20, 30, DateTimeKind.Local).AddTicks(2641), new DateTime(2024, 2, 9, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2642) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2647), new DateTime(2024, 2, 10, 13, 43, 20, 30, DateTimeKind.Local).AddTicks(2645), new DateTime(2024, 2, 10, 16, 43, 20, 30, DateTimeKind.Local).AddTicks(2646) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 18, 39, 11, 293, DateTimeKind.Local).AddTicks(6810), new DateTime(2024, 2, 9, 10, 39, 11, 293, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 2, 9, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6808) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6816), new DateTime(2024, 2, 10, 10, 39, 11, 293, DateTimeKind.Local).AddTicks(6813), new DateTime(2024, 2, 10, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6814) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 18, 39, 11, 293, DateTimeKind.Local).AddTicks(6822), new DateTime(2024, 2, 9, 10, 39, 11, 293, DateTimeKind.Local).AddTicks(6819), new DateTime(2024, 2, 9, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6827), new DateTime(2024, 2, 10, 10, 39, 11, 293, DateTimeKind.Local).AddTicks(6824), new DateTime(2024, 2, 10, 13, 39, 11, 293, DateTimeKind.Local).AddTicks(6826) });
        }
    }
}
