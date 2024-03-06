using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModDatesFiles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 22, 15, 4, 888, DateTimeKind.Local).AddTicks(7690), new DateTime(2024, 2, 7, 14, 15, 4, 888, DateTimeKind.Local).AddTicks(7641), new DateTime(2024, 2, 7, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7688) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7696), new DateTime(2024, 2, 8, 14, 15, 4, 888, DateTimeKind.Local).AddTicks(7692), new DateTime(2024, 2, 8, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 22, 15, 4, 888, DateTimeKind.Local).AddTicks(7703), new DateTime(2024, 2, 7, 14, 15, 4, 888, DateTimeKind.Local).AddTicks(7699), new DateTime(2024, 2, 7, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7708), new DateTime(2024, 2, 8, 14, 15, 4, 888, DateTimeKind.Local).AddTicks(7705), new DateTime(2024, 2, 8, 17, 15, 4, 888, DateTimeKind.Local).AddTicks(7707) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 2, 44, 57, 930, DateTimeKind.Local).AddTicks(5001), new DateTime(2024, 2, 6, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(4958), new DateTime(2024, 2, 6, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(4999) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5006), new DateTime(2024, 2, 7, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(5002), new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 2, 44, 57, 930, DateTimeKind.Local).AddTicks(5014), new DateTime(2024, 2, 6, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 2, 6, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5018), new DateTime(2024, 2, 7, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(5015), new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5017) });
        }
    }
}
