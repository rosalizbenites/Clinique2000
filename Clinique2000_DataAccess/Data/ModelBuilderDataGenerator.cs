using Clinique2000_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Data
{
    public static class ModelBuilderDataGenerator
    {
        public static void GenerateData(this ModelBuilder builder)
        {
            //var fake = new Bogus();

            //builder.Entity<User>().HasData(fake.Users);

            builder.Entity<Clinique>().HasData(
                new Clinique
                {
                    Id = 1,
                    Nom = "Clinique de la Santé",
                    Adresse = "945 Chemin de Chambly, Longueuil, QC J4H 3M6",
                    CodePostal = "J4H 3M6",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 30,
                    Latitude = 45.535579,
                    Longitude = -73.495117
                },
                new Clinique
                {
                    Id = 2,
                    Nom = "Clinique du Fort Chambly",
                    Adresse = "1101 Boulevard Brassard #205, Chambly, QC J3L 5R4",
                    CodePostal = "J3L 5R4",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 20,
                    Latitude = 45.44332,
                    Longitude = -73.3023845
                },
                new Clinique
                {
                    Id = 3,
                    Nom = "CLSC Saint-Hubert",
                    Adresse = "6800 Boulevard Cousineau, Saint-Hubert, QC J3Y 8Z4",
                    CodePostal = "J3Y 8Z4",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 20,
                    Latitude = 45.492619,
                    Longitude = -73.403113
                },
                new Clinique
                {
                    Id = 4,
                    Nom = "Clinique Azur",
                    Adresse = "2984 Boulevard Taschereau #103, Greenfield Park, QC J4V 2G9",
                    CodePostal = "J4V 2G9",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 20,
                    Latitude = 45.497723,
                    Longitude = -73.483849
                },
                new Clinique
                {
                    Id = 5,
                    Nom = "Clinique médicale Carré Saint-Lambert",
                    Adresse = "299 Boulevard Sir-Wilfrid-Laurier #100A, Saint-Lambert, QC J4R 2L1",
                    CodePostal = "J4R 2L1",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 20,
                    Latitude = 45.494032,
                    Longitude = -73.505787
                },
                new Clinique
                {
                    Id = 6,
                    Nom = "Centre Medical Bethanie",
                    Adresse = "5645 Grande Allée #50, Brossard, QC J4Z 3G3",
                    CodePostal = "J4Z 3G3",
                    Telephone = "(123) 456-7890",
                    Courriel = "clinique@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 20,
                    Latitude = 45.474260,
                    Longitude = -73.443476
                },
                new Clinique
                {
                    Id = 7,
                    Nom = "Clinique médicale L'Gros Luxe",
                    Adresse = "217 Rue Saint-Charles O, Longueuil, QC J4H 1E1",
                    CodePostal = "J4H 1E1",
                    Telephone = "1234567891",
                    Courriel = "clinique2@clinique2000.com",
                    NombreMaximumPatients = 30,
                    DureeParConsultation = 30,
                    Latitude = 45.538029,
                    Longitude = -73.510469
                }
            );

            builder.Entity<FileDAttente>().HasData(
                new FileDAttente
                {
                    Id = 1,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = new DateTime(2024, 1, 30, 20, 0, 0),
                    DateHeureOuverture = new DateTime(2024, 1, 31, 8, 0, 0),
                    DateHeureFermeture = new DateTime(2024, 1, 31, 23, 0, 0),
                    NombreMedecins = 3,
                    CliniqueId = 1
                },

                new FileDAttente
                {
                    Id = 2,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = DateTime.Now.AddHours(-3),
                    DateHeureOuverture = DateTime.Now,
                    DateHeureFermeture = DateTime.Now.AddHours(5),
                    NombreMedecins = 3,
                    CliniqueId = 1
                },

                new FileDAttente
                {
                    Id = 3,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = DateTime.Now.AddDays(1).AddHours(-3),
                    DateHeureOuverture = DateTime.Now.AddDays(1),
                    DateHeureFermeture = DateTime.Now.AddDays(1).AddHours(5),
                    NombreMedecins = 3,
                    CliniqueId = 1
                },
                new FileDAttente
                {
                    Id = 4,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = new DateTime(2024, 1, 30, 20, 0, 0),
                    DateHeureOuverture = new DateTime(2024, 1, 31, 8, 0, 0),
                    DateHeureFermeture = new DateTime(2024, 1, 31, 23, 0, 0),
                    NombreMedecins = 3,
                    CliniqueId = 7
                },

                new FileDAttente
                {
                    Id = 5,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = DateTime.Now.AddHours(-3),
                    DateHeureOuverture = DateTime.Now,
                    DateHeureFermeture = DateTime.Now.AddHours(5),
                    NombreMedecins = 3,
                    CliniqueId = 7
                },

                new FileDAttente
                {
                    Id = 6,
                    EstFermeeManuellement = false,
                    DateHeureInscriptions = DateTime.Now.AddDays(1).AddHours(-3),
                    DateHeureOuverture = DateTime.Now.AddDays(1),
                    DateHeureFermeture = DateTime.Now.AddDays(1).AddHours(5),
                    NombreMedecins = 3,
                    CliniqueId = 7
                }
            );

            builder.Entity<PlageHoraire>().HasData(
                new PlageHoraire()
                {
                    Id = 1,
                    EstReservee = true,
                    Debut = new TimeSpan(9, 0, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 2,
                    EstReservee = true,
                    Debut = new TimeSpan(9, 30, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 3,
                    EstReservee = true,
                    Debut = new TimeSpan(10, 0, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 4,
                    EstReservee = true,
                    Debut = new TimeSpan(10, 30, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 5,
                    EstReservee = true,
                    Debut = new TimeSpan(11, 0, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 6,
                    EstReservee = true,
                    Debut = new TimeSpan(11, 30, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 7,
                    // EstReservee = false, // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                    Debut = new TimeSpan(12, 0, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 8,
                    EstReservee = true,
                    Debut = new TimeSpan(12, 30, 0),
                    FileDAttenteId = 2 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },
                new PlageHoraire()
                {
                    Id = 9,
                    EstReservee = true,
                    Debut = new TimeSpan(9, 0, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 10,
                    EstReservee = true,
                    Debut = new TimeSpan(9, 30, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 11,
                    EstReservee = true,
                    Debut = new TimeSpan(10, 0, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 12,
                    EstReservee = true,
                    Debut = new TimeSpan(10, 30, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 13,
                    EstReservee = true,
                    Debut = new TimeSpan(11, 0, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 14,
                    EstReservee = true,
                    Debut = new TimeSpan(11, 30, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 15,
                    // EstReservee = false, // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                    Debut = new TimeSpan(12, 0, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                },

                new PlageHoraire()
                {
                    Id = 16,
                    EstReservee = true,
                    Debut = new TimeSpan(12, 30, 0),
                    FileDAttenteId = 5 // NE PAS MODIFIER: SERT AUX TESTS FONCTIONNELS DE LA RECHERCHE DE CLINIQUES
                }
            );

        }
    }
}

