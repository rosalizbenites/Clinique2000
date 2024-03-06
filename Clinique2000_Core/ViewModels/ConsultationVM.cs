using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.ViewModels
{
    public class ConsultationVM
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NumeroAssuranceMaladie { get; set; }
        public TimeSpan HeurePrevueRV { get; set; }
        public int PlageHoraireId { get; set; }
        public int FileDAttenteId { get; set; }
        public bool EstDerniereConsultation { get; set; } = false;
    }
}
