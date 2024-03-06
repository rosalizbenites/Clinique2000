using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.ViewModels
{
    public class PatientViewModel
    {
        [Display(Name ="Patient")]
        public string Prenom { get; set; }

        public string NomAbbrege { get; set; }

        [Display(Name = "Plage horaire")]
        public string HeurePlageHoraire { get; set; }

        public PatientViewModel(PlageHoraire plageHoraire)
        {
            if (plageHoraire.Patient != null)
            {
                Prenom = plageHoraire.Patient.Prenom;
                NomAbbrege = plageHoraire.Patient.Nom.Substring(0, 1) + ".";
                HeurePlageHoraire = plageHoraire.Debut.ToString("hh\\:mm");
            }

            else
            {
                Prenom = "";
                NomAbbrege = "";
                HeurePlageHoraire = plageHoraire.Debut.ToString("hh\\:mm");
            }

        }
    }
}
