using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class TelephonesCliniques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "Telephone",
                value: "(123) 456-7890");

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 0, 22, 55, 946, DateTimeKind.Local).AddTicks(8932), new DateTime(2024, 2, 5, 16, 22, 55, 946, DateTimeKind.Local).AddTicks(8895), new DateTime(2024, 2, 5, 19, 22, 55, 946, DateTimeKind.Local).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 19, 22, 55, 946, DateTimeKind.Local).AddTicks(8936), new DateTime(2024, 2, 6, 16, 22, 55, 946, DateTimeKind.Local).AddTicks(8934), new DateTime(2024, 2, 6, 19, 22, 55, 946, DateTimeKind.Local).AddTicks(8935) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 1,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 2,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 3,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 4,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 5,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 6,
                column: "Telephone",
                value: "1234567890");

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 5, 23, 43, 42, 996, DateTimeKind.Local).AddTicks(5412), new DateTime(2024, 2, 5, 15, 43, 42, 996, DateTimeKind.Local).AddTicks(5376), new DateTime(2024, 2, 5, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5417), new DateTime(2024, 2, 6, 15, 43, 42, 996, DateTimeKind.Local).AddTicks(5414), new DateTime(2024, 2, 6, 18, 43, 42, 996, DateTimeKind.Local).AddTicks(5416) });
        }
    }
}
