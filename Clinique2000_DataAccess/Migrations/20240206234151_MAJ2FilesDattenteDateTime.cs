using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJ2FilesDattenteDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 6, 23, 41, 50, 967, DateTimeKind.Local).AddTicks(1678), new DateTime(2024, 2, 6, 15, 41, 50, 967, DateTimeKind.Local).AddTicks(1640), new DateTime(2024, 2, 6, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1676) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1683), new DateTime(2024, 2, 7, 15, 41, 50, 967, DateTimeKind.Local).AddTicks(1680), new DateTime(2024, 2, 7, 18, 41, 50, 967, DateTimeKind.Local).AddTicks(1681) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
