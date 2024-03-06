// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;

namespace Clinique2000_Web.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly ILogger<LogoutModel> _logger;
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(ILogger<LogoutModel> logger, SignInManager<User> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
