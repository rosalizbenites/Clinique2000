using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models.AnnotationsPersonnalisees
{
    public class HeurePileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object valeur, ValidationContext validationContext)
        {
            if (valeur is DateTime valeurDateTime)
            {
                // Vérifie si l'heure et les minutes sont pile (les minutes doivent être 0)
                if (valeurDateTime.Minute == 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("La date et l'heure doivent avoir des heures piles (par exemple, 8h00, 9h00, etc.).");
                }
            }

            return new ValidationResult("Type de donnée invalide pour ce champ.");
        }
    }
}
