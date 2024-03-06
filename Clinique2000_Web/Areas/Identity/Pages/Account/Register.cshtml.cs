// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
//using Clinique2000_DataAccess.Migrations;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Clinique2000_Web.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterModel(
            IUserStore<User> userStore,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _userStore = userStore;
            _signInManager = signInManager;
            _userManager = userManager;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

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
            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [EmailAddress]
            [Display(Name = "Courriel")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "Le {0} est obligatoire")]
            [StringLength(100, ErrorMessage = "Le {0} doit comporter minimum {1} caractères.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            /// 
            [Required(ErrorMessage = "Le champ {0} est obligatoire")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmez le mot de passe")]
            [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
            public string ConfirmPassword { get; set; }

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
            
            
           




        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                user.Nom = Input.Nom;
                user.Prenom = Input.Prenom;
                user.Telephone = SupprimerCaracteresNonNumeriques(Input.Telephone);                           


                var result = await _userManager.CreateAsync(user, Input.Password);
                


                if (result.Succeeded)
                {

                    _logger.LogInformation("User created a new account with password.");

                    TempData[Constants.Success] = $"Utilisateur {user.Prenom + " " + user.Nom} ajouté";

                   // await _userManager.AddToRoleAsync(user, Constants.UtilisateurRole);
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }


                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }

        private string SupprimerCaracteresNonNumeriques(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
