// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services;
using Clinique2000_Utility;
using Clinique2000_Services.Services.IServices;

namespace Clinique2000_Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(SignInManager<User> signInManager, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Nom")]
            [StringLength(100)]
            public string Nom { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Prénom")]
            [StringLength(100)]
            public string Prenom { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Téléphone")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(([0-9]{3})\)[ ]([0-9]{3})[-]([0-9]{4})$", ErrorMessage = "Veuillez entrer un format valide (999) 999-9999.")]
            public string Telephone { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Numéro d'assurance maladie")]
            [StringLength(12)]
            public string? NumeroAssuranceMaladie { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Date de Naissance")]
            [DataType(DataType.Date)]           
            [DateRange]
            public DateTime? DatedeNaissance { get; set; }

            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [Display(Name = "Code Postal")]
            [DataType(DataType.PostalCode)]
            [StringLength(7, ErrorMessage = "Le code postal doit comporter 6 caractères..")]
            public string? CodePostal { get; set; }

            
            [Display(Name = "Adresse")]
            public string? Adresse { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = user.Telephone;
            var prenom = user.Prenom;
            var nom = user.Nom;
            var nam = user.NumeroAssuranceMaladie;
            var dateDeNaissance = user.DateDeNaissance;
            var codePostal = user.CodePostal;
            var adresse = user.Adresse;

            Username = userName;

            Input = new InputModel
            {
                Telephone = phoneNumber,
                Prenom = prenom,
                Nom = nom,
                NumeroAssuranceMaladie = nam,
                DatedeNaissance = dateDeNaissance,
                CodePostal = codePostal,
                Adresse = adresse
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Impossible de charger l'utilisateur avec l'ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            user.Prenom = Input.Prenom;
            user.Nom = Input.Nom;
            user.Telephone = SupprimerCaracteresNonNumeriques(Input.Telephone);
            user.NumeroAssuranceMaladie = Input.NumeroAssuranceMaladie;
            user.DateDeNaissance = Input.DatedeNaissance;
            user.CodePostal = Input.CodePostal;
            user.Adresse = Input.Adresse;

            if (user.CodePostal is not null)
            {
                user.Latitude = _unitOfWork.AzureMaps.ObtenirCoordonnees(user.CodePostal).Latitude;
                user.Longitude = _unitOfWork.AzureMaps.ObtenirCoordonnees(user.CodePostal).Longitude;
            }


            var result = await _userManager.UpdateAsync(user);

            var phoneNumber = user.Telephone;
            if (Input.Telephone != phoneNumber)
            {

                // var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.Telephone);
                var setPhoneResult = TryUpdateModelAsync(user, Input.Telephone);

                if (!setPhoneResult.IsCompletedSuccessfully)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Constants.PatientRole);

            }

            await _signInManager.RefreshSignInAsync(user);
            // StatusMessage = "Votre profil a été mis a jour";
            TempData[Constants.Success] = $"Votre profil a été mis a jour";
            return LocalRedirect("/"); 
        }

        private string SupprimerCaracteresNonNumeriques(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
