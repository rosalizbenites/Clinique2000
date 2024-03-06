using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        // Dépendances
        public Clinique2000DbContext DbContext { get; private set; }
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        public UserManager<User> UserManager { get; private set; }

        // Services
        public IAzureMapsService AzureMaps { get; private set; }
        public ICliniqueService Clinique { get; private set; }
        public IFileDAttenteService FileDAttente { get; private set; }
        public IPlageHoraireService PlageHoraire { get; private set; }
        public IUserService User { get; private set; }

        public UnitOfWork(Clinique2000DbContext db, IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {
            // Injections
            DbContext = db;
            HttpContextAccessor = contextAccessor;
            UserManager = userManager;

            // Services
            User = new UserService(UserManager, HttpContextAccessor);
            AzureMaps = new AzureMapsService();
            FileDAttente = new FileDAttenteService(DbContext);
            Clinique = new CliniqueService(DbContext, AzureMaps);
            PlageHoraire = new PlageHoraireService(DbContext, Clinique, User);
        }
    }
}
