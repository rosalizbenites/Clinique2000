using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.ViewModels
{
    public class ConfirmationRDVVM
    {

        public string NomPatient { get; set; }
        public DateTime DateRendezVous { get; set; }
        public string HeureRendezVous { get; set; }
        public string NomClinique { get; set; }
        public string AdresseClinique { get; set; }
        public string TelephoneClinique { get; set; }        

    }
}
