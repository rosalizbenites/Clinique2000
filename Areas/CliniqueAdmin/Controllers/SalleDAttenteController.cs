using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Clinique2000_Web.Areas.CliniqueAdmin.Controllers
{
    [Area("CliniqueAdmin")]
    [Authorize(Roles = Constants.CliniqueAdminRole)]
    public class SalleDAttenteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalleDAttenteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Patients
        public async Task<IActionResult> ChoisirClinique()
        {
            List<Clinique> cliniques = await _unitOfWork.DbContext.Cliniques.Include(f => f.FilesDAttente).ToListAsync();
            cliniques = _unitOfWork.Clinique.ObtenirListeCliniquesOuvertes(cliniques);

            if (cliniques.Count == 0)
            {
                ViewBag.Message = "Aucune file d'attente n'est ouverte";
            }

            return View(cliniques);
        }

        // GET: SalleDattente/SalleAttente/5
        public async Task<IActionResult> SalleAttente(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clinique clinique = await _unitOfWork.Clinique.GetByIdAsync(id);

            FileDAttente? fileDAttente = _unitOfWork.Clinique.ObtenirFileDAttenteInscriptionsActives(clinique);

            var SalleDattente = fileDAttente.PlagesHoraires.Where(ph => ph.EstReservee == true)
                .Select(ph => new PatientViewModel(ph))
                .OrderBy(ph => ph.HeurePlageHoraire)
                .ThenBy(ph => ph.Prenom)
                .ThenBy(ph => ph.NomAbbrege).ToList();

            if (SalleDattente.Count == 0)
            {
                ViewBag.Message = "Aucun patient n'a pris de rendez-vous";
            }

            return View(SalleDattente);
        }
    }
}
