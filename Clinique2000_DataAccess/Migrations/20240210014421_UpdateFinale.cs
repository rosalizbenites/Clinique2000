using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class UpdateFinale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 1, 44, 21, 234, DateTimeKind.Local).AddTicks(7379), new DateTime(2024, 2, 9, 17, 44, 21, 234, DateTimeKind.Local).AddTicks(7338), new DateTime(2024, 2, 9, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7377) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7385), new DateTime(2024, 2, 10, 17, 44, 21, 234, DateTimeKind.Local).AddTicks(7381), new DateTime(2024, 2, 10, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7383) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 1, 44, 21, 234, DateTimeKind.Local).AddTicks(7391), new DateTime(2024, 2, 9, 17, 44, 21, 234, DateTimeKind.Local).AddTicks(7388), new DateTime(2024, 2, 9, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 10, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7395), new DateTime(2024, 2, 10, 17, 44, 21, 234, DateTimeKind.Local).AddTicks(7393), new DateTime(2024, 2, 10, 20, 44, 21, 234, DateTimeKind.Local).AddTicks(7394) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
