using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface IPlageHoraireService : IServiceBaseAsync<PlageHoraire>
    {
        Task<FileDAttente> CreerPlagesHoraires(FileDAttente fileDAttente);
        Task<IEnumerable<PlageHoraire>> GetAllByFileDAttenteId(int _FileDAttenteId);
        Task<PlageHoraire> VerifierPlageHoraireReserve(string _PatientId);
        Task<List<PlageHoraire>> VerificationListConsultationMedecin(int _FileDAttenteId, string _MedecinId);
        //Task<PlageHoraire> VerifierPlageHoraireReserve(int _FileDAttenteId, string _PatientId);
    }
}
