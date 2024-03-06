﻿// <auto-generated />
using System;
using Clinique2000_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    [DbContext(typeof(Clinique2000DbContext))]
    [Migration("20240202034525_roleMedecin")]
    partial class roleMedecin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clinique2000_Models.Models.Clinique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CliniqueAdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DureeParConsultation")
                        .HasColumnType("int");

                    b.Property<DateTime?>("HeureOuverture")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreMaximumPatients")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CliniqueAdminId");

                    b.ToTable("Cliniques");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adresse = "945 Chemin de Chambly, Longueuil, QC J4H 3M6",
                            CodePostal = "J4H 3M6",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 30,
                            Latitude = 45.535578999999998,
                            Longitude = -73.495116999999993,
                            Nom = "Clinique de la Santé",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            Adresse = "1101 Boulevard Brassard #205, Chambly, QC J3L 5R4",
                            CodePostal = "J3L 5R4",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 20,
                            Latitude = 45.44332,
                            Longitude = -73.302384500000002,
                            Nom = "Clinique du Fort Chambly",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = 3,
                            Adresse = "6800 Boulevard Cousineau, Saint-Hubert, QC J3Y 8Z4",
                            CodePostal = "J3Y 8Z4",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 20,
                            Latitude = 45.492618999999998,
                            Longitude = -73.403113000000005,
                            Nom = "CLSC Saint-Hubert",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = 4,
                            Adresse = "2984 Boulevard Taschereau #103, Greenfield Park, QC J4V 2G9",
                            CodePostal = "J4V 2G9",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 20,
                            Latitude = 45.497723000000001,
                            Longitude = -73.483849000000006,
                            Nom = "Clinique Azur",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = 5,
                            Adresse = "299 Boulevard Sir-Wilfrid-Laurier #100A, Saint-Lambert, QC J4R 2L1",
                            CodePostal = "J4R 2L1",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 20,
                            Latitude = 45.494031999999997,
                            Longitude = -73.505786999999998,
                            Nom = "Clinique médicale Carré Saint-Lambert",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        },
                        new
                        {
                            Id = 6,
                            Adresse = "5645 Grande Allée #50, Brossard, QC J4Z 3G3",
                            CodePostal = "J4Z 3G3",
                            Courriel = "clinique@clinique2000.com",
                            DureeParConsultation = 20,
                            Latitude = 45.474260000000001,
                            Longitude = -73.443476000000004,
                            Nom = "Centre Medical Bethanie",
                            NombreMaximumPatients = 30,
                            Telephone = "1234567890"
                        });
                });

            modelBuilder.Entity("Clinique2000_Models.Models.FileDAttente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CliniqueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateHeureFermeture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateHeureInscriptions")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateHeureOuverture")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EstFermeeManuellement")
                        .HasColumnType("bit");

                    b.Property<int>("NombreMedecins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CliniqueId");

                    b.ToTable("FilesDAttente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CliniqueId = 1,
                            DateHeureFermeture = new DateTime(2024, 1, 31, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            DateHeureInscriptions = new DateTime(2024, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            DateHeureOuverture = new DateTime(2024, 1, 31, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            EstFermeeManuellement = false,
                            NombreMedecins = 3
                        },
                        new
                        {
                            Id = 2,
                            CliniqueId = 1,
                            DateHeureFermeture = new DateTime(2024, 2, 2, 3, 45, 25, 420, DateTimeKind.Local).AddTicks(7903),
                            DateHeureInscriptions = new DateTime(2024, 2, 1, 19, 45, 25, 420, DateTimeKind.Local).AddTicks(7861),
                            DateHeureOuverture = new DateTime(2024, 2, 1, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7901),
                            EstFermeeManuellement = false,
                            NombreMedecins = 3
                        },
                        new
                        {
                            Id = 3,
                            CliniqueId = 1,
                            DateHeureFermeture = new DateTime(2024, 2, 2, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7909),
                            DateHeureInscriptions = new DateTime(2024, 2, 2, 19, 45, 25, 420, DateTimeKind.Local).AddTicks(7905),
                            DateHeureOuverture = new DateTime(2024, 2, 2, 22, 45, 25, 420, DateTimeKind.Local).AddTicks(7907),
                            EstFermeeManuellement = false,
                            NombreMedecins = 3
                        });
                });

            modelBuilder.Entity("Clinique2000_Models.Models.PlageHoraire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Debut")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("DebutReel")
                        .HasColumnType("time");

                    b.Property<bool>("EstReservee")
                        .HasColumnType("bit");

                    b.Property<int>("FileDAttenteId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("FinReelle")
                        .HasColumnType("time");

                    b.Property<string>("MedecinId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumeroMedecin")
                        .HasColumnType("int");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FileDAttenteId");

                    b.HasIndex("MedecinId");

                    b.HasIndex("PatientId");

                    b.ToTable("PlagesHoraires");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Debut = new TimeSpan(0, 9, 0, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 2,
                            Debut = new TimeSpan(0, 9, 30, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 3,
                            Debut = new TimeSpan(0, 10, 0, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 4,
                            Debut = new TimeSpan(0, 10, 30, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 5,
                            Debut = new TimeSpan(0, 11, 0, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 6,
                            Debut = new TimeSpan(0, 11, 30, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 7,
                            Debut = new TimeSpan(0, 12, 0, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        },
                        new
                        {
                            Id = 8,
                            Debut = new TimeSpan(0, 12, 30, 0, 0),
                            EstReservee = true,
                            FileDAttenteId = 1,
                            NumeroMedecin = 0
                        });
                });

            modelBuilder.Entity("Clinique2000_Models.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodePostal")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NumeroAssuranceMaladie")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Clinique2000_Models.Models.Clinique", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.User", "CliniqueAdmin")
                        .WithMany("Cliniques")
                        .HasForeignKey("CliniqueAdminId");

                    b.Navigation("CliniqueAdmin");
                });

            modelBuilder.Entity("Clinique2000_Models.Models.FileDAttente", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.Clinique", "Clinique")
                        .WithMany("FilesDAttente")
                        .HasForeignKey("CliniqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinique");
                });

            modelBuilder.Entity("Clinique2000_Models.Models.PlageHoraire", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.FileDAttente", "FileDAttente")
                        .WithMany("PlagesHoraires")
                        .HasForeignKey("FileDAttenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinique2000_Models.Models.User", "Medecin")
                        .WithMany("Consultations")
                        .HasForeignKey("MedecinId");

                    b.HasOne("Clinique2000_Models.Models.User", "Patient")
                        .WithMany("PlagesHoraires")
                        .HasForeignKey("PatientId");

                    b.Navigation("FileDAttente");

                    b.Navigation("Medecin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinique2000_Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Clinique2000_Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Clinique2000_Models.Models.Clinique", b =>
                {
                    b.Navigation("FilesDAttente");
                });

            modelBuilder.Entity("Clinique2000_Models.Models.FileDAttente", b =>
                {
                    b.Navigation("PlagesHoraires");
                });

            modelBuilder.Entity("Clinique2000_Models.Models.User", b =>
                {
                    b.Navigation("Cliniques");

                    b.Navigation("Consultations");

                    b.Navigation("PlagesHoraires");
                });
#pragma warning restore 612, 618
        }
    }
}