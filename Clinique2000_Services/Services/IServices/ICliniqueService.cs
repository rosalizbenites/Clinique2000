using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface ICliniqueService : IServiceBaseAsync<Clinique>
    {
        public FileDAttente? ObtenirFileDAttenteInscriptionsActives(Clinique clinique);
        public TimeSpan? ObtenirHeureProchainePlageHoraireDisponible(Clinique clinique);
        public List<TimeSpan?> ObtenirListeHeuresProchainesPlagesHorairesDisponible(List<Clinique> cliniques);
        public List<Clinique> ObtenirListeCliniquesOuvertes(List<Clinique> cliniques);
        public bool VerifierSiPlageHoraireLibre(FileDAttente? fileDAttente);
        public bool VerifierSiFileDAttenteInscriptionsActives(Clinique clinique);
        public List<Clinique> TrierCliniques(User userCourant, List<Clinique> cliniques);
        public CliniqueFileDAttenteVM ObtenirCliniqueFileDAttente(Clinique clinique);
    }
}
