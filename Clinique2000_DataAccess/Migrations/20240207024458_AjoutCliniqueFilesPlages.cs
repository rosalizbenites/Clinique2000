using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutCliniqueFilesPlages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "Id", "Adresse", "CliniqueAdminId", "CodePostal", "Courriel", "DureeParConsultation", "HeureOuverture", "Latitude", "Longitude", "Nom", "NombreMaximumPatients", "Telephone" },
                values: new object[] { 7, "945 Chemin de Chambly, Longueuil, QC J4H 3M7", null, "J4H 3M7", "clinique2@clinique2000.com", 30, null, 45.535578999999998, -73.495116999999993, "Clinique de la Santé 2", 30, "1234567891" });

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

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 4, 7, new DateTime(2024, 1, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), false, 3 });

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 5, 7, new DateTime(2024, 2, 7, 2, 44, 57, 930, DateTimeKind.Local).AddTicks(5014), new DateTime(2024, 2, 6, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(5011), new DateTime(2024, 2, 6, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5013), false, 3 });

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 6, 7, new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5018), new DateTime(2024, 2, 7, 18, 44, 57, 930, DateTimeKind.Local).AddTicks(5015), new DateTime(2024, 2, 7, 21, 44, 57, 930, DateTimeKind.Local).AddTicks(5017), false, 3 });

            migrationBuilder.InsertData(
                table: "PlagesHoraires",
                columns: new[] { "Id", "Debut", "DebutReel", "EstReservee", "FileDAttenteId", "FinReelle", "MedecinId", "NumeroMedecin", "PatientId" },
                values: new object[,]
                {
                    { 9, new TimeSpan(0, 9, 0, 0, 0), null, true, 5, null, null, 0, null },
                    { 10, new TimeSpan(0, 9, 30, 0, 0), null, true, 5, null, null, 0, null },
                    { 11, new TimeSpan(0, 10, 0, 0, 0), null, true, 5, null, null, 0, null },
                    { 12, new TimeSpan(0, 10, 30, 0, 0), null, true, 5, null, null, 0, null },
                    { 13, new TimeSpan(0, 11, 0, 0, 0), null, true, 5, null, null, 0, null },
                    { 14, new TimeSpan(0, 11, 30, 0, 0), null, true, 5, null, null, 0, null },
                    { 15, new TimeSpan(0, 12, 0, 0, 0), null, false, 5, null, null, 0, null },
                    { 16, new TimeSpan(0, 12, 30, 0, 0), null, true, 5, null, null, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PlagesHoraires",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cliniques",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 1, 18, 50, 475, DateTimeKind.Local).AddTicks(7519), new DateTime(2024, 2, 6, 17, 18, 50, 475, DateTimeKind.Local).AddTicks(7478), new DateTime(2024, 2, 6, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "FilesDAttente",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture" },
                values: new object[] { new DateTime(2024, 2, 7, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7524), new DateTime(2024, 2, 7, 17, 18, 50, 475, DateTimeKind.Local).AddTicks(7521), new DateTime(2024, 2, 7, 20, 18, 50, 475, DateTimeKind.Local).AddTicks(7523) });
        }
    }
}
