using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<User>> ObtenirListeMedecinsParClinique(int CliniqueId)
        {
            List<User> Medecins = new List<User>();

            var userMedecin = await _userManager.GetUsersInRoleAsync(Constants.MedecinRole);
            if (userMedecin != null)
            {
                Medecins = userMedecin.Where(m => m.CliniqueId == CliniqueId).ToList();
            }
            return Medecins;
        }

        public async Task<User> ObtenirUtilisateurCourantAsync()
        {
            var userId = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                var user = await _userManager.FindByIdAsync(userId);
                return user;
            }

            return null; // Aucun utilisateur n'est présentement connecté
        }

        public async Task<bool> ValiderRoleAsync(string id, string role)
        {
            var user = await ObtenirUtilisateurCourantAsync();

            if (user == null)
            {
                return false; // Aucun utilisateur n'est présentement connecté
            }

            // Noter que les noms exacts des rôles peuvent être trouvés dans Clinique_Utility/Constants.cs
            return await _userManager.IsInRoleAsync(user, role);
        }
    }
}
