using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class Reinitialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroAssuranceMaladie = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliniques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeureOuverture = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NombreMaximumPatients = table.Column<int>(type: "int", nullable: false),
                    DureeParConsultation = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CliniqueAdminId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliniques_AspNetUsers_CliniqueAdminId",
                        column: x => x.CliniqueAdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilesDAttente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstFermeeManuellement = table.Column<bool>(type: "bit", nullable: false),
                    DateHeureInscriptions = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateHeureOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateHeureFermeture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreMedecins = table.Column<int>(type: "int", nullable: false),
                    CliniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesDAttente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesDAttente_Cliniques_CliniqueId",
                        column: x => x.CliniqueId,
                        principalTable: "Cliniques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlagesHoraires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstReservee = table.Column<bool>(type: "bit", nullable: false),
                    NumeroMedecin = table.Column<int>(type: "int", nullable: false),
                    Debut = table.Column<TimeSpan>(type: "time", nullable: false),
                    DebutReel = table.Column<TimeSpan>(type: "time", nullable: true),
                    FinReelle = table.Column<TimeSpan>(type: "time", nullable: true),
                    FileDAttenteId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MedecinId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagesHoraires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlagesHoraires_AspNetUsers_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlagesHoraires_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlagesHoraires_FilesDAttente_FileDAttenteId",
                        column: x => x.FileDAttenteId,
                        principalTable: "FilesDAttente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "Id", "Adresse", "CliniqueAdminId", "CodePostal", "Courriel", "DureeParConsultation", "HeureOuverture", "Latitude", "Longitude", "Nom", "NombreMaximumPatients", "Telephone" },
                values: new object[,]
                {
                    { 1, "945 Chemin de Chambly, Longueuil, QC J4H 3M6", null, "J4H 3M6", "clinique@clinique2000.com", 30, null, 45.535578999999998, -73.495116999999993, "Clinique de la Santé", 30, "1234567890" },
                    { 2, "1101 Boulevard Brassard #205, Chambly, QC J3L 5R4", null, "J3L 5R4", "clinique@clinique2000.com", 20, null, 45.44332, -73.302384500000002, "Clinique du Fort Chambly", 30, "1234567890" },
                    { 3, "6800 Boulevard Cousineau, Saint-Hubert, QC J3Y 8Z4", null, "J3Y 8Z4", "clinique@clinique2000.com", 20, null, 45.492618999999998, -73.403113000000005, "CLSC Saint-Hubert", 30, "1234567890" },
                    { 4, "2984 Boulevard Taschereau #103, Greenfield Park, QC J4V 2G9", null, "J4V 2G9", "clinique@clinique2000.com", 20, null, 45.497723000000001, -73.483849000000006, "Clinique Azur", 30, "1234567890" },
                    { 5, "299 Boulevard Sir-Wilfrid-Laurier #100A, Saint-Lambert, QC J4R 2L1", null, "J4R 2L1", "clinique@clinique2000.com", 20, null, 45.494031999999997, -73.505786999999998, "Clinique médicale Carré Saint-Lambert", 30, "1234567890" },
                    { 6, "5645 Grande Allée #50, Brossard, QC J4Z 3G3", null, "J4Z 3G3", "clinique@clinique2000.com", 20, null, 45.474260000000001, -73.443476000000004, "Centre Medical Bethanie", 30, "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 1, 1, new DateTime(2024, 1, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), false, 3 });

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 2, 1, new DateTime(2024, 2, 2, 2, 11, 33, 90, DateTimeKind.Local).AddTicks(2094), new DateTime(2024, 2, 1, 18, 11, 33, 90, DateTimeKind.Local).AddTicks(2051), new DateTime(2024, 2, 1, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2092), false, 3 });

            migrationBuilder.InsertData(
                table: "FilesDAttente",
                columns: new[] { "Id", "CliniqueId", "DateHeureFermeture", "DateHeureInscriptions", "DateHeureOuverture", "EstFermeeManuellement", "NombreMedecins" },
                values: new object[] { 3, 1, new DateTime(2024, 2, 2, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2099), new DateTime(2024, 2, 2, 18, 11, 33, 90, DateTimeKind.Local).AddTicks(2096), new DateTime(2024, 2, 2, 21, 11, 33, 90, DateTimeKind.Local).AddTicks(2098), false, 3 });

            migrationBuilder.InsertData(
                table: "PlagesHoraires",
                columns: new[] { "Id", "Debut", "DebutReel", "EstReservee", "FileDAttenteId", "FinReelle", "MedecinId", "NumeroMedecin", "PatientId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 9, 0, 0, 0), null, true, 1, null, null, 0, null },
                    { 2, new TimeSpan(0, 9, 30, 0, 0), null, true, 1, null, null, 0, null },
                    { 3, new TimeSpan(0, 10, 0, 0, 0), null, true, 1, null, null, 0, null },
                    { 4, new TimeSpan(0, 10, 30, 0, 0), null, true, 1, null, null, 0, null },
                    { 5, new TimeSpan(0, 11, 0, 0, 0), null, true, 1, null, null, 0, null },
                    { 6, new TimeSpan(0, 11, 30, 0, 0), null, true, 1, null, null, 0, null },
                    { 7, new TimeSpan(0, 12, 0, 0, 0), null, true, 1, null, null, 0, null },
                    { 8, new TimeSpan(0, 12, 30, 0, 0), null, true, 1, null, null, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cliniques_CliniqueAdminId",
                table: "Cliniques",
                column: "CliniqueAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_FilesDAttente_CliniqueId",
                table: "FilesDAttente",
                column: "CliniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_FileDAttenteId",
                table: "PlagesHoraires",
                column: "FileDAttenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_MedecinId",
                table: "PlagesHoraires",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_PatientId",
                table: "PlagesHoraires",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PlagesHoraires");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FilesDAttente");

            migrationBuilder.DropTable(
                name: "Cliniques");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
