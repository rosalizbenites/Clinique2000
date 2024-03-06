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

namespace Clinique2000_Web.Areas.Utilisateur.Controllers
{
	[Area("Utilisateur")]
	public class CliniquesController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CliniquesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: Cliniques/Create
		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		// POST: Cliniques/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create(Clinique clinique)
		{
			clinique.Latitude = _unitOfWork.AzureMaps.ObtenirCoordonnees(clinique.CodePostal).Latitude;
			clinique.Longitude = _unitOfWork.AzureMaps.ObtenirCoordonnees(clinique.CodePostal).Longitude;

			if (ModelState.IsValid)
			{

				clinique.Telephone = SupprimerCaracteresNonNumeriques(clinique.Telephone);
				_unitOfWork.DbContext.Add(clinique);
				await _unitOfWork.DbContext.SaveChangesAsync();
				int lastClinicId = clinique.Id;
				TempData[Constants.Success] = $"Clinique {clinique.Nom} ajoutée";
				return RedirectToAction("Details", new { id = lastClinicId });
			}

			TempData[Constants.Error] = $"Clinique {clinique.Nom} n'ai pas été ajoutée.";
			return View(clinique);
		}

		private string SupprimerCaracteresNonNumeriques(string input)
		{
			return new string(input.Where(char.IsDigit).ToArray());
		}

	}
}
