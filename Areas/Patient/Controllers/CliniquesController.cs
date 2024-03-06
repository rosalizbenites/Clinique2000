using Clinique2000_Models.Models;
using Clinique2000_Models.ViewModels;
using Clinique2000_Services.Services.IServices;
using Clinique2000_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinique2000_Web.Areas.Patient.Controllers
{
	[Area("Patient")]
	public class CliniquesController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CliniquesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		//[Authorize(Roles = Constants.PatientRole)]
		// GET: Cliniques		
		public async Task<IActionResult> Recherche()
		{
			User userCourant = await _unitOfWork.User.ObtenirUtilisateurCourantAsync();

			bool estPatient = await _unitOfWork.User.ValiderRoleAsync(userCourant.Id, Constants.PatientRole);

			if (!estPatient)
			{
				RedirectToPage("/Account/Manage/Index", new { area = "Identity" });
			}

			RechercheCliniquesVM vm = new RechercheCliniquesVM();
			PlageHoraire verifieRDV = (PlageHoraire)await _unitOfWork.PlageHoraire.VerifierPlageHoraireReserve(userCourant.Id);

			if (userCourant != null)
			{
				if (verifieRDV != null)
				{
					var confirmationViewModel = new ConfirmationRDVVM
					{
						NomPatient = userCourant.Prenom + " " + userCourant.Nom,
						DateRendezVous = verifieRDV.FileDAttente.DateHeureOuverture,
						HeureRendezVous = verifieRDV.Debut.ToString(@"hh\:mm"),
						NomClinique = verifieRDV.FileDAttente.Clinique.Nom,
						AdresseClinique = verifieRDV.FileDAttente.Clinique.Adresse,
						TelephoneClinique = verifieRDV.FileDAttente.Clinique.Telephone
					};
					return View("RDVFixe", confirmationViewModel);
				}
				else
				{
					List<Clinique> cliniques = await _unitOfWork.DbContext.Cliniques.ToListAsync();
					List<double> distances = new List<double>();
					List<TimeSpan?> heuresProchainesPlagesHorairesDisponibles = new List<TimeSpan?>();
					List<ResultatsCliniquesVM> resultats = new List<ResultatsCliniquesVM>();

					cliniques = _unitOfWork.Clinique.TrierCliniques(userCourant, cliniques);
					distances = _unitOfWork.AzureMaps.ObtenirDistances(userCourant, cliniques);
					heuresProchainesPlagesHorairesDisponibles = _unitOfWork.Clinique.ObtenirListeHeuresProchainesPlagesHorairesDisponible(cliniques);

					if (cliniques.Count != 0)
					{
						for (int i = 0; i < cliniques.Count; i++)
						{
							resultats.Add(new ResultatsCliniquesVM
							{
								Clinique = cliniques[i],
								Distance = distances[i],
								HeureProchainePlagesHoraireDisponible = heuresProchainesPlagesHorairesDisponibles[i]
							});
						}
					}

					vm.Resultats = resultats;
					vm.LatitudeUtilisateur = userCourant.Latitude.ToString()?.Replace(',', '.');
					vm.LongitudeUtilisateur = userCourant.Longitude.ToString()?.Replace(',', '.');

					// TODO : Tester la recherche avec carte dans le cas où la recherche ne retourne aucun résultat (liste vide)
					return View(vm);
				}
			}
			vm.Erreur = "Aucun utilisateur n'est connecté.";
			return View(vm);
		}


		// GET: Cliniques/Details/5
		[Authorize]
		public async Task<IActionResult> Details(int id)
		{
			if (id == null || _unitOfWork.DbContext.Cliniques == null)
			{
				return NotFound();
			}

			var clinique = await _unitOfWork.Clinique.GetByIdAsync(id);

			CliniqueFileDAttenteVM vm = _unitOfWork.Clinique.ObtenirCliniqueFileDAttente(clinique);

			if (clinique == null)
			{
				return NotFound();
			}

			return View(vm);
		}
	}
}
