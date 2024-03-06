using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModSeedCliniques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Adresse", "CodePostal", "Latitude", "Longitude", "Nom" },
                values: new object[] { "217 Rue Saint-Charles O, Longueuil, QC J4H 1E1", "J4H 1E1", 45.538029000000002, -73.510469000000001, "Clinique médicale L'Gros Luxe" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Adresse", "CodePostal", "Latitude", "Longitude", "Nom" },
                values: new object[] { "945 Chemin de Chambly, Longueuil, QC J4H 3M7", "J4H 3M7", 45.535578999999998, -73.495116999999993, "Clinique de la Santé 2" });

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
    }
}
