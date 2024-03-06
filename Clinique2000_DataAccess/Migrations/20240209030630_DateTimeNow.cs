using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class DateTimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 3, 6, 29, 971, DateTimeKind.Local).AddTicks(3831), new DateTime(2024, 2, 8, 19, 6, 29, 971, DateTimeKind.Local).AddTicks(3788), new DateTime(2024, 2, 8, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3836), new DateTime(2024, 2, 9, 19, 6, 29, 971, DateTimeKind.Local).AddTicks(3833), new DateTime(2024, 2, 9, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3834) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 3, 6, 29, 971, DateTimeKind.Local).AddTicks(3841), new DateTime(2024, 2, 8, 19, 6, 29, 971, DateTimeKind.Local).AddTicks(3839), new DateTime(2024, 2, 8, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3840) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3848), new DateTime(2024, 2, 9, 19, 6, 29, 971, DateTimeKind.Local).AddTicks(3845), new DateTime(2024, 2, 9, 22, 6, 29, 971, DateTimeKind.Local).AddTicks(3847) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 1, 52, 6, 147, DateTimeKind.Local).AddTicks(4322), new DateTime(2024, 2, 8, 17, 52, 6, 147, DateTimeKind.Local).AddTicks(4286), new DateTime(2024, 2, 8, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4327), new DateTime(2024, 2, 9, 17, 52, 6, 147, DateTimeKind.Local).AddTicks(4324), new DateTime(2024, 2, 9, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4326) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 1, 52, 6, 147, DateTimeKind.Local).AddTicks(4332), new DateTime(2024, 2, 8, 17, 52, 6, 147, DateTimeKind.Local).AddTicks(4329), new DateTime(2024, 2, 8, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4331) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4336), new DateTime(2024, 2, 9, 17, 52, 6, 147, DateTimeKind.Local).AddTicks(4334), new DateTime(2024, 2, 9, 20, 52, 6, 147, DateTimeKind.Local).AddTicks(4335) });
        }
    }
}
