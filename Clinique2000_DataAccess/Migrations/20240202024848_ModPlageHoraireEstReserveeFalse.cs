using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModPlageHoraireEstReserveeFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 2, 48, 48, 235, DateTimeKind.Local).AddTicks(4434), new DateTime(2024, 2, 1, 18, 48, 48, 235, DateTimeKind.Local).AddTicks(4390), new DateTime(2024, 2, 1, 21, 48, 48, 235, DateTimeKind.Local).AddTicks(4432) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 21, 48, 48, 235, DateTimeKind.Local).AddTicks(4439), new DateTime(2024, 2, 2, 18, 48, 48, 235, DateTimeKind.Local).AddTicks(4436), new DateTime(2024, 2, 2, 21, 48, 48, 235, DateTimeKind.Local).AddTicks(4437) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 7,
                column: "EstReservee",
                value: false);
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

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 7,
                column: "EstReservee",
                value: true);
        }
    }
}
