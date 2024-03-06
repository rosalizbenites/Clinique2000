using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface IUnitOfWork
    {
        // Injections
        Clinique2000DbContext DbContext { get; }
        IHttpContextAccessor HttpContextAccessor { get; }
        UserManager<User> UserManager { get; }

        // Services
        IAzureMapsService AzureMaps { get; }
        ICliniqueService Clinique { get; }
        IFileDAttenteService FileDAttente { get; }
        IPlageHoraireService PlageHoraire { get; }
        IUserService User { get; }
    }
}
