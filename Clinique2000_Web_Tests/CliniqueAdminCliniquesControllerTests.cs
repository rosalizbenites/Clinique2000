using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Web.Areas.CliniqueAdmin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Web_Tests
{
    public class CliniqueAdminCliniquesControllerTests
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
                    context.SaveChanges();
                }
            }
        }

        [Fact]
        public async Task Edit_RetourneNotFound_QuandIdEstNul()
        {
            // Arrange
            var controller = new CliniquesController(null);

            // Act
            var resultat = await controller.Edit(null) as NotFoundResult;

            // Assert
            Assert.NotNull(resultat);
        }

        [Fact]
        public async Task Edit_RetourneNotFound_QuandLaCliniqueNexistePas()
        {
            using (var context = new Clinique2000DbContext(SetUpInMemory("Edit_RetourneNotFound_QuandLaCliniqueNexistePas")))
            {
                // Arrange
                var controller = new CliniquesController(null);

                // Act
                var resultat = await controller.Edit(3, new Clinique()) as NotFoundResult;

                // Assert
                Assert.NotNull(resultat);
            }
        }

        [Fact]
        public async Task Edit_RetourneVueAvecClinique_QuandLeModelStateEstInvalide()
        {
            using (var context = new Clinique2000DbContext(SetUpInMemory("Edit_RetourneVueAvecClinique_QuandLeModelStateEstInvalide")))
            {
                // Arrange
                var idClinique = 1;
                var clinique = new Clinique {
                    Id = idClinique,
                    Adresse = "945 Chemin de Chambly, Longueuil, QC J4H 3M6",
                    CodePostal = "J4H 3M6",
                    Courriel = "clinique@clinique2000.com",
                    Nom = "Clinique de la Santé",
                    Telephone = "0", // Invalide (un Telephone valide serait, par exemple, "(123) 456-7890")
                    Latitude = 45.535579,
                    Longitude = -73.495117
                };
                var controller = new CliniquesController(null);
                controller.ModelState.AddModelError("Clé", "Message d'erreur");

                // Act
                var resultat = await controller.Edit(idClinique, clinique) as ViewResult;

                // Assert
                Assert.NotNull(resultat);
                var modele = Assert.IsAssignableFrom<Clinique>(resultat.ViewData.Model);
                Assert.Equal(clinique, modele);
            }
            
        }

        [Fact]
        public async Task Edit_RetourneRedirectionVersAction_QuandLaCliniqueEstMiseAJour()
        {
            using (var context = new Clinique2000DbContext(SetUpInMemory("Edit_RetourneNotFound_QuandLaCliniqueNexistePas")))
            {
                // Arrange
                var idClinique = 1;
                var clinique = new Clinique { Id = idClinique };
                var controller = new CliniquesController(null);

                // Act
                var resultat = await controller.Edit(idClinique, clinique) as RedirectToActionResult;

                // Assert
                Assert.NotNull(resultat);
                Assert.Equal("GestionCliniques", resultat.ActionName);
            }
        }
    }
}
