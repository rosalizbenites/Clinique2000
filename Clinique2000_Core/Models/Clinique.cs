using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models
{
    public class Clinique
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Code Postal")]
        [DataType(DataType.PostalCode)]
        [StringLength(7, ErrorMessage = "Le code postal doit comporter 6 caractères avec espace")]
        [JsonIgnore]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(([0-9]{3})\)[ ]([0-9]{3})[-]([0-9]{4})$", ErrorMessage = "Veuillez entrer un format valide (999) 999-9999.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Courriel")]
        [EmailAddress]
        public string Courriel { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Heure d'ouverture")]
        [DataType(DataType.Time)]
        [JsonIgnore]
        public DateTime? HeureOuverture { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Heure de fermeture")]
        [DataType(DataType.Time)]
        public DateTime? HeureFermeture { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nombre maximum de patients")]
        [JsonIgnore]
        public int NombreMaximumPatients { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Durée par consultation")]
        [JsonIgnore]
        public int DureeParConsultation { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Display(Name = "Files d'attente")]
        [ValidateNever]
        [JsonIgnore]
        public virtual List<FileDAttente> FilesDAttente { get; set; }

        public int TempsAvantAnnulation { get; set; }   

        [Display(Name = "Administrateur de la clinique")]
        [ForeignKey("CliniqueAdmin")]
        [JsonIgnore]
        public string? CliniqueAdminId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public virtual User? CliniqueAdmin { get; set; }
    }
}
