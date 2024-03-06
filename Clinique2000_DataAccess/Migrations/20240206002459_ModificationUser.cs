using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModificationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeureFermeture",
                table: "Cliniques");

            migrationBuilder.AddColumn<int>(
                name: "CliniqueId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 0, 24, 58, 918, DateTimeKind.Local).AddTicks(3833), new DateTime(2024, 2, 5, 16, 24, 58, 918, DateTimeKind.Local).AddTicks(3798), new DateTime(2024, 2, 5, 19, 24, 58, 918, DateTimeKind.Local).AddTicks(3831) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 19, 24, 58, 918, DateTimeKind.Local).AddTicks(3837), new DateTime(2024, 2, 6, 16, 24, 58, 918, DateTimeKind.Local).AddTicks(3834), new DateTime(2024, 2, 6, 19, 24, 58, 918, DateTimeKind.Local).AddTicks(3836) });

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
            migrationBuilder.DropColumn(
                name: "CliniqueId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "HeureFermeture",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

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
