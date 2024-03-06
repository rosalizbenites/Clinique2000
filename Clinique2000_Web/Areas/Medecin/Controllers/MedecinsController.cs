using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace Clinique2000_Web.Areas.Medecin.Controllers
{

    [Area("Medecin")]
    [Authorize(Roles = Constants.MedecinRole)]
    public class MedecinsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedecinsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> GererConsultations(int FileDAttenteid)
        {
            User user = await _unitOfWork.User.ObtenirUtilisateurCourantAsync();
            

            var listplagesMedecin = await _unitOfWork.PlageHoraire.VerificationListConsultationMedecin(FileDAttenteid, user.Id);

            if (listplagesMedecin.Count == 0)
                return View(null);

            else
            {
                var plageHoraireCourante = await _unitOfWork.PlageHoraire.GetByIdAsync(listplagesMedecin[0].Id);
                plageHoraireCourante.DebutReel = DateTime.Now.TimeOfDay;
                await _unitOfWork.PlageHoraire.EditAsync(plageHoraireCourante);

                ConsultationVM Consultation = new ConsultationVM
                {
                    Nom = listplagesMedecin[0].Patient.Nom,
                    Prenom = listplagesMedecin[0].Patient.Prenom,
                    NumeroAssuranceMaladie = listplagesMedecin[0].Patient.NumeroAssuranceMaladie,
                    HeurePrevueRV = listplagesMedecin[0].Debut,
                    PlageHoraireId = listplagesMedecin[0].Id,
                    FileDAttenteId = listplagesMedecin[0].FileDAttenteId
                };

                               
                if (listplagesMedecin.Count == 1)
                    Consultation.EstDerniereConsultation = true;

                return View(Consultation);
            } 
        }
       
        // GET: MedecinsController/Details/5
        public async Task<IActionResult> GererEtatConsultations(int PlageHoraireId)
        {
            var plageHoraireCourante = await _unitOfWork.PlageHoraire.GetByIdAsync(PlageHoraireId);

            plageHoraireCourante.FinReelle = DateTime.Now.TimeOfDay;
            plageHoraireCourante.EstReservee = false;
            await _unitOfWork.PlageHoraire.EditAsync(plageHoraireCourante);

            return RedirectToAction("GererConsultations", new { FileDAttenteId = plageHoraireCourante.FileDAttenteId });
        }

        // GET: MedecinsController/Create
        public async Task<IActionResult> GererTerminerConsultations(int PlageHoraireId)
        {

            var plageHoraireCourante = await _unitOfWork.PlageHoraire.GetByIdAsync(PlageHoraireId);

            plageHoraireCourante.FinReelle = DateTime.Now.TimeOfDay;
            plageHoraireCourante.EstReservee = false;

            await _unitOfWork.PlageHoraire.EditAsync(plageHoraireCourante);

            ConsultationVM Consultation = new ConsultationVM
            {
                HeurePrevueRV = plageHoraireCourante.Debut,   
            };

            return View("ConsultationTerminee",Consultation);
        }


        public async Task<IActionResult> VoirConsultations()
        {

            User user = await _unitOfWork.User.ObtenirUtilisateurCourantAsync();
            if (user != null && user.CliniqueId != null)
            {
                var cliniqueCourante = await _unitOfWork.Clinique.GetByIdAsync((int)user.CliniqueId);
                var fileDAttenteCourante = _unitOfWork.Clinique.ObtenirFileDAttenteInscriptionsActives(cliniqueCourante);

                if (fileDAttenteCourante != null && fileDAttenteCourante.Id == null)
                {
                    ViewBag.Message = "Aucun patient n'a pris de rendez-vous";
                }

                return RedirectToAction("GererConsultations", new { FileDAttenteId = fileDAttenteCourante.Id });
            }

            return NotFound();
        }
    }
}
