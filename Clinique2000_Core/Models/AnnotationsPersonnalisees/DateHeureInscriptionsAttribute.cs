using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models.AnnotationsPersonnalisees
{
    public class DateHeureInscriptionsAttribute : ValidationAttribute
    {
        private readonly string _dateHeureOuverturePropriete;

        public DateHeureInscriptionsAttribute(string dateHeureOuverturePropriete)
        {
            _dateHeureOuverturePropriete = dateHeureOuverturePropriete;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateHeureInscriptions = (DateTime)value;

            var dateHeureOuvertureProprieteInfo = validationContext.ObjectType.GetProperty(_dateHeureOuverturePropriete);

            if (dateHeureOuvertureProprieteInfo == null)
            {
                return new ValidationResult($"Propriété inconnue: {_dateHeureOuverturePropriete}");
            }

            var dateHeureOuverture = (DateTime)dateHeureOuvertureProprieteInfo.GetValue(validationContext.ObjectInstance);

            if (dateHeureInscriptions < dateHeureOuverture.AddDays(-1).Date || dateHeureInscriptions > dateHeureOuverture)
            {
                return new ValidationResult($"La date et l'heure des inscriptions doivent être comprises entre {dateHeureOuverture.AddDays(-1).Date:yyyy-MM-dd hh:mm tt} et {dateHeureOuverture:yyyy-MM-dd hh:mm tt}.");
            }

            return ValidationResult.Success;
        }
    }
}
