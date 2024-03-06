using Clinique2000_Models.Models;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_DataAccess.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Clinique2000DbContext _db;

        public DbInitializer(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            Clinique2000DbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize()
        {
            
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            var a = _roleManager.RoleExistsAsync(Constants.AdminRole).GetAwaiter().GetResult();

            if (!_roleManager.RoleExistsAsync(Constants.AdminRole).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.AdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.UtilisateurRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.PatientRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.CliniqueAdminRole)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(Constants.MedecinRole)).GetAwaiter().GetResult();

                User user;
                Clinique clinique;
                PlageHoraire plageHoraire;


                // Cr�er un User pour le r�le Admin
                _userManager.CreateAsync(new User
                {
                    Id = "b30a0625-fe15-4139-ad23-9478d9c087c5",
                    UserName = "admin@clinique2000.com",
                    Email = "admin@clinique2000.com",
                    Nom = "Admin",
                    Prenom = "Admin",
                    NumeroAssuranceMaladie = "ADMI12345678",
                    Telephone = "(438) 123-4567",
                    DateDeNaissance = new DateTime(1950, 1, 1),
                    CodePostal = "J4L 1M2",
                    Latitude = 45.523705,
                    Longitude = -73.468048
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "admin@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.AdminRole).GetAwaiter().GetResult();


                // Cr�er deux Users pour le r�le Patient
                _userManager.CreateAsync(new User
                {
                    Id = "b59f7130-cb5f-48b8-a4af-83e88162dd67",
                    Nom = "Doe",
                    Prenom = "John",
                    UserName = "john.doe@example.com",
                    Email = "john.doe@example.com",
                    NumeroAssuranceMaladie = "ABCD12345678",
                    Telephone = "(514) 123-4567",
                    DateDeNaissance = new DateTime(1990, 1, 1),
                    CodePostal = "J4K 2V1",
                    Latitude = 45.52795,
                    Longitude = -73.5149436
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "john.doe@example.com");
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "d263bcaf-5ffb-4e50-8ea9-dc7d0648717f",
                    Nom = "Tremblay",
                    Prenom = "Jane",
                    UserName = "jane.tremblay@example.com",
                    Email = "jane.tremblay@example.com",
                    NumeroAssuranceMaladie = "DCBA87654321",
                    Telephone = "(450) 123-4567",
                    DateDeNaissance = new DateTime(2010, 1, 1),
                    CodePostal = "J4H 2T2",
                    Latitude = 45.535558,
                    Longitude = -73.512578
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "jane.tremblay@example.com");
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "d063bcaf-5ffb-4e50-8ea9-dc7d0648710f",
                    Nom = "Tremblay",
                    Prenom = "Jim",
                    UserName = "jim.tremblay@example.com",
                    Email = "jim.tremblay@example.com",
                    NumeroAssuranceMaladie = "TREJ87654321",
                    Telephone = "4505234567",
                    DateDeNaissance = new DateTime(2000, 1, 1),
                    CodePostal = "J4H 2T2",
                    Latitude = 45.535558,
                    Longitude = -73.512578
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "jim.tremblay@example.com");
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "b59f7130-cb5f-48b8-a4af-83e88162dd57",
                    Nom = "Doe",
                    Prenom = "Joanne",
                    UserName = "joanne.doe@example.com",
                    Email = "joanne.doe@example.com",
                    NumeroAssuranceMaladie = "DOEJ12345678",
                    Telephone = "5144234567",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4K 2V1",
                    Latitude = 45.52795,
                    Longitude = -73.5149436
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "joanne.doe@example.com");
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "b89f7130-cb5f-48b8-a4af-83e88162dd68",
                    Nom = "Doe",
                    Prenom = "Joseph",
                    UserName = "joseph.doe@example.com",
                    Email = "joseph.doe@example.com",
                    NumeroAssuranceMaladie = "DOEJ12345678",
                    Telephone = "5144234567",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4K 2V1",
                    Latitude = 45.52795,
                    Longitude = -73.5149436
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "joseph.doe@example.com");
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                // Cr�er un User pour le r�le CliniqueAdmin
                //Admin Clinique de la Santé et Clinique médicale L'Gros Luxe
                _userManager.CreateAsync(new User
                {
                    Id = "9661fc2e-4b9d-4deb-950d-aa889833d343",
                    UserName = "joeblo@clinique2000.com",
                    Email = "joeblo@clinique2000.com",
                    Nom = "Blo",
                    Prenom = "Joe",
                    Telephone = "(438) 888-9191",
                    DateDeNaissance = new DateTime(1980,1,1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "joeblo@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 1);
                clinique.CliniqueAdminId = user.Id;
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 7);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                //Admin Clinique du Fort Chambly
                _userManager.CreateAsync(new User
                {
                    UserName = "mme.tartempion@clinique2000.com",
                    Email = "mme.tartempion@clinique2000.com",
                    Nom = "Tartempion",
                    Prenom = "Madame",
                    Telephone = "(514) 415-1451",
                    DateDeNaissance = new DateTime(2000, 1, 1),
                    CodePostal = "J4W 2T5",
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "mme.tartempion@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 2);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                ///Admin clinique CLSC Saint-Hubert
                _userManager.CreateAsync(new User
                {
                    Id = "cf9e9a4d-585b-4b37-8bf4-faaffd2afacc",
                    UserName = "pablo@clinique2000.com",
                    Email = "pablo@clinique2000.com",
                    Nom = "Jimenez",
                    Prenom = "Pablo",
                    Telephone = "5141889191",
                    DateDeNaissance = new DateTime(1999, 1, 1),
                    CodePostal = "J4J 3E3",
                    Latitude = 45.5203815,
                    Longitude = -73.481817
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "pablo@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 3);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                ///Admin Clinique Azur
                _userManager.CreateAsync(new User
                {
                    Id = "0061fc2e-4b9d-4deb-950d-aa889833d300",
                    UserName = "rosa@clinique2000.com",
                    Email = "rosa@clinique2000.com",
                    Nom = "Benites",
                    Prenom = "Rosa",
                    Telephone = "4311889191",
                    DateDeNaissance = new DateTime(1982, 1, 1),
                    CodePostal = "J4K 2T8",
                    Latitude = 45.528175,
                    Longitude = -73.521431
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "rosa@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 4);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                ///Admin Clinique médicale Carré Saint-Lambert
                _userManager.CreateAsync(new User
                {
                    Id = "c12e9a4d-585b-4b37-8bf4-faaffd2afac0",
                    UserName = "eve@clinique2000.com",
                    Email = "eve@clinique2000.com",
                    Nom = "Jimenez",
                    Prenom = "Eve",
                    Telephone = "5145889191",
                    DateDeNaissance = new DateTime(1999, 1, 1),
                    CodePostal = "J4J 3E3",
                    Latitude = 45.5203815,
                    Longitude = -73.481817
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "eve@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 5);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                ///Admin Centre Medical Bethanie
                _userManager.CreateAsync(new User
                {
                    Id = "123e9a4d-585b-4b37-8bf4-faaffd2afacc",
                    UserName = "bethanie@clinique2000.com",
                    Email = "bethanie@clinique2000.com",
                    Nom = "Jimenez",
                    Prenom = "bethanie",
                    Telephone = "5145489191",
                    DateDeNaissance = new DateTime(1999, 1, 1),
                    CodePostal = "J4J 3E3",
                    Latitude = 45.5203815,
                    Longitude = -73.481817
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "bethanie@clinique2000.com");
                clinique = _db.Cliniques.FirstOrDefault(c => c.Id == 6);
                clinique.CliniqueAdminId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.CliniqueAdminRole).GetAwaiter().GetResult();
                #region Medecin
                // Creer un User pour le role medecin Clinique du Fort Chambly
                _userManager.CreateAsync(new User
                {
                    Id = "1161fc2e-4b9d-4deb-950d-aa889833d300",
                    UserName = "jim@clinique2000.com",
                    Email = "jim@clinique2000.com",
                    Nom = "Browns",
                    Prenom = "Jim",
                    Telephone = "4188889091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 2

                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "jim@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                // Cr�er un User pour le r�le M�decin clinique ST Hubert
                //
                _userManager.CreateAsync(new User
                {
                    Id = "1161fc2e-4b9d-4deb-950d-aa889833d399",
                    UserName = "mich@clinique2000.com",
                    Email = "mich@clinique2000.com",
                    Nom = "Browns",
                    Prenom = "Mich",
                    Telephone = "4168889091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 3

                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "mich@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                ////Cr�er un User pour le r�le M�decin clinique AZUR

                _userManager.CreateAsync(new User
                {
                    Id = "1161fc2e-4b9d-4deb-950d-aa889833d311",
                    UserName = "michael@clinique2000.com",
                    Email = "michael@clinique2000.com",
                    Nom = "Brown",
                    Prenom = "Michael",
                    Telephone = "4318889091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 4

                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "michael@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "1261fc2e-4b9d-4deb-950d-aa889833d321",
                    UserName = "samantha@clinique2000.com",
                    Email = "samantha@clinique2000.com",
                    Nom = "Davis",
                    Prenom = "Samantha",
                    Telephone = "5311889091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 4
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "samantha@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "1361fc2e-4b9d-4deb-950d-aa889833d331",
                    UserName = "olivia@clinique2000.com",
                    Email = "olivia@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "Olivia",
                    Telephone = "5141889091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 4
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "olivia@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                
                //médecins clinique Santé
                _userManager.CreateAsync(new User
                {
                    Id = "8361fc2e-4b9d-4deb-950d-aa889833d338",
                    UserName = "ronald@clinique2000.com",
                    Email = "ronald@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "Ronald",
                    Telephone = "5145589091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 1
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "ronald@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                _userManager.CreateAsync(new User
                {
                    Id = "7361fc2e-4b9d-4deb-950d-aa889833d337",
                    UserName = "melanie@clinique2000.com",
                    Email = "melanie@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "Melanie",
                    Telephone = "5145619091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 1
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "melanie@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();

                //médecins clinique médicale Carré Saint-Lambert
                _userManager.CreateAsync(new User
                {
                    Id = "7361fc2e-4b9d-4deb-950d-aa889833d987",
                    UserName = "lili@clinique2000.com",
                    Email = "lili@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "lili",
                    Telephone = "5145149091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 5
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "lili@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();

                //médecins clinique médicale Bethanie
                _userManager.CreateAsync(new User
                {
                    Id = "7361fc2e-4b9d-4deb-950d-aa889833d988",
                    UserName = "julia@clinique2000.com",
                    Email = "julia@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "Julia",
                    Telephone = "5145149091",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 6
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "julia@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                //médecins clinique médicale L'Gros Luxe
                _userManager.CreateAsync(new User
                {
                    Id = "7361fc2e-4b9d-4deb-950d-aa889833d989",
                    UserName = "jeanpierre@clinique2000.com",
                    Email = "jeanpierre@clinique2000.com",
                    Nom = "Martin",
                    Prenom = "Jean Pierre",
                    Telephone = "5145149591",
                    DateDeNaissance = new DateTime(1980, 1, 1),
                    CodePostal = "J4H 3P8",
                    Latitude = 45.539021,
                    Longitude = -73.496909,
                    CliniqueId = 7
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "jeanpierre@clinique2000.com");
                _userManager.AddToRoleAsync(user, Constants.MedecinRole).GetAwaiter().GetResult();
                #endregion
                #region DoctorWho
                // Cr�er des patients additionnels pour tester la salle d'attente
                _userManager.CreateAsync(new User
                {
                    Id = "c57b9262-5fdd-4327-8aa7-4556fa1ba332",
                    UserName = "TheDoctor",
                    Email = "iamthedoctor@gallifrey.com",
                    Nom = "Smith",
                    Prenom = "John",
                    Telephone = "1234567890",
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "iamthedoctor@gallifrey.com");
                
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 1);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "f1e9ced2-db98-4ae6-a340-ac8ae0195449",
                    UserName = "RoseTyler",
                    Email = "myjobburned@powellestate.com",
                    Nom = "Tyler",
                    Prenom = "Rose",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "myjobburned@powellestate.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 2);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "e54b0b40-32e6-4ea5-b856-2ed3a1ecd5ed",
                    UserName = "MarthaJones",
                    Email = "barefootonthe@moon.com",
                    Nom = "Jones",
                    Prenom = "Martha",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "barefootonthe@moon.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 3);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "36fc9f9a-02fe-46fd-b585-67e5b45e084f",
                    UserName = "DonnaNoble",
                    Email = "wherami@wot.com",
                    Nom = "Noble",
                    Prenom = "Donna",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "wherami@wot.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 4);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "2beb57bd-8ac5-4ee3-be4b-d6df8938251a",
                    UserName = "AmyPond",
                    Email = "comealongpond@imaginaryfriend.com",
                    Nom = "Pond",
                    Prenom = "Amelia",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "comealongpond@imaginaryfriend.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 5);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "5ac100e6-b2ac-4141-acf1-ec0aa1b5acd9",
                    UserName = "Rory",
                    Email = "thelastcenturion@pandorica.com",
                    Nom = "Williams",
                    Prenom = "Rory",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "thelastcenturion@pandorica.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 6);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "14daa4fa-c900-48f4-ab79-83b1a282c906",
                    UserName = "RiverSong",
                    Email = "hellosweetie@thedoctor.com",
                    Nom = "Pond",
                    Prenom = "Melody",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "hellosweetie@thedoctor.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 7);
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                _userManager.CreateAsync(new User
                {
                    Id = "ac0de3f8-d3e9-44de-8c6b-dd77ff83167c",
                    UserName = "Clara",
                    Email = "run@youcleverboy.com",
                    Nom = "Oswald",
                    Prenom = "Clara",
                    Telephone = "1234567890"
                    // Attention, ce patient n'a pas de NumeroAssuranceMaladie, DateDeNaissance, CodePostal, Latitude, Longitude
                }, "Password1!").GetAwaiter().GetResult();
                user = _db.Users.FirstOrDefault(u => u.Email == "run@youcleverboy.com");
                plageHoraire = _db.PlagesHoraires.FirstOrDefault(c => c.Id == 8);
                plageHoraire.PatientId = user.Id;
                _userManager.AddToRoleAsync(user, Constants.PatientRole).GetAwaiter().GetResult();

                #endregion

            }
            return;
        }
    }



}

