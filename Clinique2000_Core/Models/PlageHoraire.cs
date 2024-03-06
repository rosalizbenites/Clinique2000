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
    public class PlageHoraire
    {
        [Key]
        public int Id { get; set; }

        public bool EstReservee { get; set; }

        [Display(Name = "Début")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public TimeSpan Debut { get; set; }

        [Display(Name = "Début réel")]
        public TimeSpan? DebutReel { get; set; }

        [Display(Name = "Fin réelle")]
        public TimeSpan? FinReelle { get; set; }

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
        [ValidateNever]
        [JsonIgnore]
        public virtual User? Patient { get; set; }


        [Display(Name = "Médecin")]
        [ForeignKey("Medecin")]
        [JsonIgnore]
        public string? MedecinId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public virtual User? Medecin { get; set; }

        [ForeignKey("PlageHoraireAnnule")]
        [JsonIgnore]
        public PlageHoraireAnnule? PlageHoraireAnnuleId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public PlageHoraireAnnule PlageHoraireAnnule { get; set; }

    }
}
