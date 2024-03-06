using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinique2000_Models.Models.AnnotationsPersonnalisees;
using System.Text.Json.Serialization;

namespace Clinique2000_Models.Models
{
    public class FileDAttente
    {
        [Key]
        public int Id { get; set; }

        //La file d'attente est ouverte (et non les inscriptions) => la journée commence et le premier patient se pointe
        [Display(Name = "Fermée manuellement")]
        public bool EstFermeeManuellement { get; set; }

        // Date et heure à laquelle les patients peuvent commencer à s'inscrire à une plage horaire
        [Display(Name = "Date et heure des inscriptions")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [HeurePile]
        [DateHeureInscriptions(nameof(DateHeureOuverture))]
        [FuturDate(ErrorMessage = "La date et l'heure doivent être dans le futur.")]
        public DateTime DateHeureInscriptions { get; set; }

        // Date et heure de l'ouverture de la file d'attente
        [Display(Name = "Date et heure d'ouverture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [HeurePile]
        [AvantDate(nameof(DateHeureFermeture), ErrorMessage = "La date et l'heure d'ouverture doivent être avant celles de la fermeture.")]
        [FuturDate(ErrorMessage = "La date et l'heure doivent être dans le futur.")]
        public DateTime DateHeureOuverture { get; set; }

        // Date et heure de la fermeture de la file d'attente
        [Display(Name = "Date et heure de fermeture")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [HeurePile]
        [FuturDate(ErrorMessage = "La date et l'heure doivent être dans le futur.")]
        public DateTime DateHeureFermeture { get; set; }

        [Display(Name = "Nombre de médecins")]
        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage="Il faut au moins 1 médecin")]
        public int NombreMedecins { get; set; }

        [Display(Name = "Clinique")]
        [ForeignKey("Clinique")]
        [JsonIgnore]
        public int CliniqueId { get; set; }
        [ValidateNever]
        [JsonIgnore]
        public virtual Clinique Clinique { get; set; }

        [Display(Name = "Plages horaires")]
        [ValidateNever]
        [JsonIgnore]
        public virtual List<PlageHoraire> PlagesHoraires { get; set; }
    }
}
