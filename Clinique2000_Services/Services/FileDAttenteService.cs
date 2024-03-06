using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class FileDAttenteService : ServiceBaseAsync<FileDAttente>, IFileDAttenteService
    {
        public FileDAttenteService(Clinique2000DbContext db) : base(db) { }
    }
}
