using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace Clinique2000_Models.Models
{
    public class PlageHoraireAnnule
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Début")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan Debut { get; set; }

        [Display(Name = "File d'attente")]
        [ForeignKey("FileDAttente")]
        [JsonIgnore]
        public int FileDAttenteId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public virtual FileDAttente FileDAttente { get; set; }


        [Display(Name = "Patient")]
        [ForeignKey("Patient")]
        [JsonIgnore]
        public string? PatientId { get; set; }
        

        [Display(Name = "Médecin")]
        [ForeignKey("Medecin")]
        [JsonIgnore]
        public string? MedecinId { get; set; }

        public string raisonAnnulation { get; set; }

        [JsonIgnore]
        public PlageHoraire PlageHoraire { get; set; }

    }
}
