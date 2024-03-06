using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJHeureClinique1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 41, 26, 470, DateTimeKind.Local).AddTicks(3981), new DateTime(2024, 2, 8, 12, 41, 26, 470, DateTimeKind.Local).AddTicks(3944), new DateTime(2024, 2, 8, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3979) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3987), new DateTime(2024, 2, 9, 12, 41, 26, 470, DateTimeKind.Local).AddTicks(3983), new DateTime(2024, 2, 9, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 41, 26, 470, DateTimeKind.Local).AddTicks(3993), new DateTime(2024, 2, 8, 12, 41, 26, 470, DateTimeKind.Local).AddTicks(3990), new DateTime(2024, 2, 8, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3992) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 9, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3999), new DateTime(2024, 2, 9, 12, 41, 26, 470, DateTimeKind.Local).AddTicks(3996), new DateTime(2024, 2, 9, 15, 41, 26, 470, DateTimeKind.Local).AddTicks(3997) });
        }
    }
}
