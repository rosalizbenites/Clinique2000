using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJDATETIME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { DateTime.Now.AddHours(5), DateTime.Now.AddHours(-3), DateTime.Now });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { DateTime.Now.AddDays(1).AddHours(5), DateTime.Now.AddDays(1).AddHours(-3), DateTime.Now.AddDays(1) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { DateTime.Now.AddHours(5), DateTime.Now.AddHours(-3), DateTime.Now });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { DateTime.Now.AddDays(1).AddHours(5), DateTime.Now.AddDays(1).AddHours(-3), DateTime.Now.AddDays(1) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
