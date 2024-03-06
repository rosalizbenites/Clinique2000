using Microsoft.AspNetCore.Identity;
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
    public class User :  IdentityUser
    {
        [Display(Name = "Nom")]
        [StringLength(100)]
        public string Nom { get; set; }

        [Display(Name = "Prénom")]
        [StringLength(100)]
        public string Prenom { get; set; }

        [Display(Name = "Numéro d'assurance maladie")]
        [StringLength(12)]
        public string? NumeroAssuranceMaladie { get; set; }

        [Display(Name = "Téléphone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(([0-9]{3})\)[ ]([0-9]{3})[-]([0-9]{4})$", ErrorMessage = "Veuillez entrer un format valide (999) 999-9999.")]
        public string Telephone { get; set; }
        
        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]        
        [DateRange]
        public DateTime? DateDeNaissance { get; set; }

        [Display(Name = "Code Postal")]
        [DataType(DataType.PostalCode)]
        [StringLength(7, ErrorMessage = "Le code postal doit comporter 6 caractères avec espace")]
        public string? CodePostal { get; set; }

        [Display(Name = "Adresse")]
        public string? Adresse { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? CliniqueId { get; set; }

        [Display(Name = "Plages horaires")]
        [ValidateNever]
        [JsonIgnore]
        public virtual List<PlageHoraire>? PlagesHoraires { get; set; }

        [Display(Name = "Consultations")]
        [ValidateNever]
        [JsonIgnore]
        public virtual List<PlageHoraire>? Consultations { get; set; }

        [Display(Name = "Cliniques")]
        [ValidateNever]
        [JsonIgnore]
        public virtual List<Clinique>? Cliniques { get; set; }
    }

   


}
