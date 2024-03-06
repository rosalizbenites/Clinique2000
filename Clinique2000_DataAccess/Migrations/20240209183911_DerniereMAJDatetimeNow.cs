using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class DerniereMAJDatetimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
