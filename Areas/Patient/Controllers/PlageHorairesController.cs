using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Clinique2000_Web.Areas.Patient.Controllers
{

    [Area("Patient")]
    //[Authorize(Roles = Constants.PatientRole)]
    public class PlageHorairesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlageHorairesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: PlageHoraireController
        public async Task<IActionResult> Index(int CliniqueId)
        {
            Clinique objClinique = await _unitOfWork.Clinique.GetByIdAsync(CliniqueId);
            int FileDAttenteId = 0;
            var fileCourante = _unitOfWork.Clinique.ObtenirFileDAttenteInscriptionsActives(objClinique);
            if (fileCourante != null)
                FileDAttenteId = fileCourante.Id;

            TimeSpan heureActuelle = DateTime.Now.TimeOfDay;            

            List<PlageHoraire> PlageHoraireList = (List<PlageHoraire>)await _unitOfWork.PlageHoraire.GetAllByFileDAttenteId(FileDAttenteId);

            if (fileCourante.DateHeureOuverture.Date == DateTime.Now.Date)
            {
            // Montrer plages horaires disponibles ET plages horaires du présent et du futur
                for (int x = PlageHoraireList.Count - 1; x >= 0; x--)
                {                   
                    if (PlageHoraireList[x].Debut <= heureActuelle)
                    {
                        PlageHoraireList.RemoveAt(x);
                    }

                }
            }
            
            // Montrer tous plages horaires disponibles
            return View(PlageHoraireList);                     

        }

        // GET: PlageHoraireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> UpdateReserveStatus(int id)
        {
            User user = await _unitOfWork.User.ObtenirUtilisateurCourantAsync();
            var plageHoraire = await _unitOfWork.PlageHoraire.GetByIdAsync(id);
            PlageHoraire verifieRDV = (PlageHoraire) await _unitOfWork.PlageHoraire.VerifierPlageHoraireReserve(user.Id);

            if (verifieRDV == null)
            {
                if (plageHoraire == null)
                {
                    return NotFound();
                }

                plageHoraire.EstReservee = true;
                plageHoraire.PatientId = user.Id;
                await _unitOfWork.PlageHoraire.EditAsync(plageHoraire);

                return View("ConfirmationRDV", await RendezVousAssigne(id));
            }
            
            return View("RDVFixe",await RendezVousAssigne(verifieRDV.Id));
        }

        public async Task<ConfirmationRDVVM> RendezVousAssigne(int id)
        {
            User user = await _unitOfWork.User.ObtenirUtilisateurCourantAsync();
            var plageHoraire = await _unitOfWork.PlageHoraire.GetByIdAsync(id);
           
            var confirmationViewModel = new ConfirmationRDVVM
            {
                NomPatient = user.Prenom + " " + user.Nom,
                DateRendezVous = plageHoraire.FileDAttente.DateHeureOuverture,
                HeureRendezVous = plageHoraire.Debut.ToString(@"hh\:mm"),
                NomClinique = plageHoraire.FileDAttente.Clinique.Nom,
                AdresseClinique = plageHoraire.FileDAttente.Clinique.Adresse,
                TelephoneClinique = plageHoraire.FileDAttente.Clinique.Telephone
            };

            return confirmationViewModel;
        }
    }
}
