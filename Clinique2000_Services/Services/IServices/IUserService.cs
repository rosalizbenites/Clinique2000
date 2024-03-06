using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface IUserService
    {
        Task<User> ObtenirUtilisateurCourantAsync();
        Task<bool> ValiderRoleAsync(string id, string role);
        Task<List<User>> ObtenirListeMedecinsParClinique(int CliniqueId);
    }
}
