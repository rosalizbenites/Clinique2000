using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModPlageHorairesFileDAttenteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 2, 59, 58, 882, DateTimeKind.Local).AddTicks(9562), new DateTime(2024, 2, 1, 18, 59, 58, 882, DateTimeKind.Local).AddTicks(9526), new DateTime(2024, 2, 1, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 2, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9568), new DateTime(2024, 2, 2, 18, 59, 58, 882, DateTimeKind.Local).AddTicks(9565), new DateTime(2024, 2, 2, 21, 59, 58, 882, DateTimeKind.Local).AddTicks(9567) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 1,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 7,
                column: "FileDAttenteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 8,
                column: "FileDAttenteId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 2,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 3,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 4,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 5,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 6,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 7,
                column: "FileDAttenteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 8,
                column: "FileDAttenteId",
                value: 1);
        }
    }
}
