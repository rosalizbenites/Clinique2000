using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services.IServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class CliniqueService : ServiceBaseAsync<Clinique>, ICliniqueService
    {
        private readonly IAzureMapsService _azureMapsService;

        public CliniqueService(Clinique2000DbContext db, IAzureMapsService azureMapsService) : base(db)
        {
            _azureMapsService = azureMapsService;
        }

        public FileDAttente? ObtenirFileDAttenteInscriptionsActives(Clinique clinique)
        {
            DateTime maintenant = DateTime.Now;
            return clinique.FilesDAttente.Where(f =>
            f.DateHeureInscriptions <= maintenant &&
            f.DateHeureFermeture >= maintenant
            ).FirstOrDefault();
        }

        public TimeSpan? ObtenirHeureProchainePlageHoraireDisponible(Clinique clinique)
        {
            FileDAttente? fileDAttenteInscriptionsActives = ObtenirFileDAttenteInscriptionsActives(clinique);

            if (fileDAttenteInscriptionsActives != null)
            {
                foreach (var plageHoraire in fileDAttenteInscriptionsActives.PlagesHoraires)
                {
                    if (plageHoraire.EstReservee == false)
                    {
                        return plageHoraire.Debut;
                    }
                }
            }

            return null;
        }

        public List<TimeSpan?> ObtenirListeHeuresProchainesPlagesHorairesDisponible(List<Clinique> cliniques)
        {
            List<TimeSpan?> resultat = new List<TimeSpan?>();

            foreach (var clinique in cliniques)
            {
                if (ObtenirHeureProchainePlageHoraireDisponible(clinique) != null)
                {
                    resultat.Add(ObtenirHeureProchainePlageHoraireDisponible(clinique));
                }
            }

            return resultat;
        }

        public List<Clinique> ObtenirListeCliniquesOuvertes(List<Clinique> cliniques)
        {
            DateTime maintenant = DateTime.Now;
            return cliniques.Where(
                c => c.FilesDAttente.Where(
                    f => f.DateHeureOuverture <= maintenant && f.DateHeureFermeture >= maintenant)
                .FirstOrDefault() != null)
                .ToList();
        }

        public bool VerifierSiPlageHoraireLibre(FileDAttente? fileDAttente)
        {
            if (fileDAttente != null)
            {
                foreach (var plageHoraire in fileDAttente.PlagesHoraires)
                {
                    if (plageHoraire.EstReservee == false)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool VerifierSiFileDAttenteInscriptionsActives(Clinique clinique)
        {
            FileDAttente? fileDAttente = ObtenirFileDAttenteInscriptionsActives(clinique);
            return fileDAttente == null ? false : true;
        }

        private List<Clinique> TrierCliniquesSelonDistance(User userCourant, List<Clinique> cliniques)
        {
            return _azureMapsService.TrierCliniquesSelonDistance(userCourant, cliniques);
        }

        private List<Clinique> TrierCliniquesSelonInscriptionsActives(List<Clinique> cliniques)
        {
            return cliniques.Where(clinique => VerifierSiFileDAttenteInscriptionsActives(clinique)).ToList();
        }

        private List<Clinique> TrierCliniquesSelonSiPlageHoraireLibre(List<Clinique> cliniques)
        {
            return cliniques.Where(clinique => VerifierSiPlageHoraireLibre(ObtenirFileDAttenteInscriptionsActives(clinique))).ToList();
        }

        public List<Clinique> TrierCliniques(User userCourant, List<Clinique> cliniques)
        {
            cliniques = TrierCliniquesSelonInscriptionsActives(cliniques);
            cliniques = TrierCliniquesSelonSiPlageHoraireLibre(cliniques);
            return TrierCliniquesSelonDistance(userCourant, cliniques);
        }

        public CliniqueFileDAttenteVM ObtenirCliniqueFileDAttente(Clinique clinique)
        {
            CliniqueFileDAttenteVM vm = new CliniqueFileDAttenteVM
            {
                cliniqueCourante = clinique,
                fileDAttenteActive = ObtenirFileDAttenteInscriptionsActives(clinique)
            };

            return vm;
        }

    }
}
