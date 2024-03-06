using Clinique2000_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services;

namespace Clinique2000_Services_Tests
{
    public class AzureMapsServiceTests
    {
        private DbContextOptions<Clinique2000DbContext> SetUpInMemory(string uniqueName)
        {
            var options = new DbContextOptionsBuilder<Clinique2000DbContext>().UseInMemoryDatabase(uniqueName).Options;
            SeedInMemoryStore(options);
            return options;
        }

        private void SeedInMemoryStore(DbContextOptions<Clinique2000DbContext> options)
        {

            using (var context = new Clinique2000DbContext(options))
            {
                if (!context.Cliniques.Any())
                {
                    // Ajouter un User
                    context.Users.Add(new User
                    {
                        Nom = "Smith",
                        Prenom = "John",
                        Telephone = "(514) 123-4567",
                        Latitude = 45.52795,
                        Longitude = -73.5149436
                    });

                    // Ajouter deux Cliniques
                    context.Cliniques.Add(new Clinique
                    {
                        Adresse = "945 Chemin de Chambly, Longueuil, QC J4H 3M6",
                        CodePostal = "J4H 3M6",
                        Courriel = "clinique@clinique2000.com",
                        Nom = "Clinique de la Santé",
                        Telephone = "(123) 456-7890",
                        Latitude = 45.535579,
                        Longitude = -73.495117
                    });
                    context.Cliniques.Add(new Clinique
                    {
                        Adresse = "217 Rue Saint-Charles O, Longueuil, QC J4H 1E1",
                        CodePostal = "J4H 1E1",
                        Courriel = "clinique2@clinique2000.com",
                        Nom = "Clinique médicale L'Gros Luxe",
                        Telephone = "1234567891",
                        Latitude = 45.538029,
                        Longitude = -73.510469
                    });
                    context.SaveChanges();
                }
            }
        }

        [Fact]
        public void ObtenirDistances_RetourneDistancesCorrectes()
        {
            using (var context = new Clinique2000DbContext(SetUpInMemory("ObtenirDistances_RetourneDistancesCorrectes")))
            {
                // Arrange
                AzureMapsService service = new AzureMapsService();
                User utilisateur = context.Users.FirstOrDefault();
                List<Clinique> cliniques = context.Cliniques.ToList();

                // Act
                List<double> distances = service.ObtenirDistances(utilisateur, cliniques);

                // Assert
                Assert.NotNull(distances);
                Assert.Equal(2, distances.Count); // Vérifie que le nombre de distances retournées est correct

                // Calculer les distances attendues
                double distanceClinique1 = CalculerDistance((double)utilisateur.Latitude, (double)utilisateur.Longitude, cliniques[0].Latitude, cliniques[0].Longitude);
                double distanceClinique2 = CalculerDistance((double)utilisateur.Latitude, (double)utilisateur.Longitude, cliniques[1].Latitude, cliniques[1].Longitude);

                // Définir les distances attendues avec une précision
                double distanceClinique1Attendue = 1.7620118026322638; // Exemple de distance attendue pour la clinique 1 (en kilomètres)
                double distanceClinique2Attendue = 1.1736782302548945; // Exemple de distance attendue pour la clinique 2 (en kilomètres)

                // Vérifier que les distances retournées correspondent aux distances attendues avec une précision donnée
                Assert.InRange(distances[0], distanceClinique1Attendue - 0.01, distanceClinique1Attendue + 0.01); // Vérifie que la distance retournée pour clinique 1 est proche de la distance attendue
                Assert.InRange(distances[1], distanceClinique2Attendue - 0.01, distanceClinique2Attendue + 0.01); // Vérifie que la distance retournée pour clinique 2 est proche de la distance attendue
            }
        }

        private double CalculerDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            const double R = 6371; // Rayon de la Terre en kilomètres

            // Convertir la latitude et la longitude de degrés à radians
            latitude1 = EnRadians(latitude1);
            longitude1 = EnRadians(longitude1);
            latitude2 = EnRadians(latitude2);
            longitude2 = EnRadians(longitude2);

            // Calculer les différences
            double differenceLat = latitude2 - latitude1;
            double differenceLon = longitude2 - longitude1;

            // Formule de Haversine
            double a = Math.Pow(Math.Sin(differenceLat / 2), 2) + Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Pow(Math.Sin(differenceLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculer la distance
            double distance = R * c;

            return distance;
        }

        private double EnRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }
    }
}
