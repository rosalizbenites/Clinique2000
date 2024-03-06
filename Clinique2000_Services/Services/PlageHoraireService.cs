using Clinique2000_DataAccess.Data;
using Clinique2000_Models.Models;
using Clinique2000_Services.Services.IServices;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services
{
    public class PlageHoraireService : ServiceBaseAsync<PlageHoraire>, IPlageHoraireService
    {
        private readonly ICliniqueService _cliniqueService;
        private readonly IUserService _userService;

        public PlageHoraireService(Clinique2000DbContext db, ICliniqueService cliniqueService, IUserService userService) : base(db)
        {
            _cliniqueService = cliniqueService;
            _userService = userService;
        }

        public async Task<FileDAttente> CreerPlagesHoraires(FileDAttente fileDAttente)
        {
            Clinique clinique = await _cliniqueService.GetByIdAsync(fileDAttente.CliniqueId);
            fileDAttente.PlagesHoraires = new List<PlageHoraire>();
            List<User> ListeMedecin = await _userService.ObtenirListeMedecinsParClinique(clinique.Id);
            DateTime t = fileDAttente.DateHeureOuverture;

            while (t <= fileDAttente.DateHeureFermeture.AddMinutes(-clinique.DureeParConsultation))
            {
                for (int i = 0; i < fileDAttente.NombreMedecins; i++)
                {
                    fileDAttente.PlagesHoraires.Add(new PlageHoraire
                    {
                        Debut = new TimeSpan(t.Hour, t.Minute, t.Second),
                        MedecinId = ListeMedecin[i].Id,
                    });
                }
                t = t.AddMinutes(clinique.DureeParConsultation);
            }

            if (ListeMedecin.Count < fileDAttente.NombreMedecins)
            {
                throw new Exception("Il n'y a pas assez de médecins pour la création des plages horaires.");
            }

            return fileDAttente;
        }

        public async Task<IEnumerable<PlageHoraire>> GetAllByFileDAttenteId(int _FileDAttenteId)
        {
            List< PlageHoraire > PlageHoraires = new List< PlageHoraire >();

            if (_db.PlagesHoraires != null || _db.PlagesHoraires.Any())
            {
                var plageHoraires = await _db.PlagesHoraires
                .Where(p => p.EstReservee == false && p.FileDAttenteId == _FileDAttenteId)
                .GroupBy(p => p.Debut)
                .Select(p => p.FirstOrDefault())
                .ToListAsync();

                return plageHoraires;
            }

            return PlageHoraires;
        }

       
        public async Task<PlageHoraire> VerifierPlageHoraireReserve(string _PatientId)
        {
            var VerificationPlageHoraire = await _db.PlagesHoraires
               .Where(p => p.EstReservee == true && p.FinReelle==null && p.PatientId == _PatientId)
               .FirstOrDefaultAsync();

            return VerificationPlageHoraire;

        }

        public async Task<List<PlageHoraire>> VerificationListConsultationMedecin(int _FileDAttenteId,string _MedecinId)

        {
            var ListConsultationActive = await _db.PlagesHoraires
                .Where(p => p.EstReservee == true && p.FileDAttenteId == _FileDAttenteId && p.MedecinId == _MedecinId && p.FinReelle == null)
                .OrderBy(p => p.Debut)
                .ToListAsync();
            return ListConsultationActive;

        }
    }
}
