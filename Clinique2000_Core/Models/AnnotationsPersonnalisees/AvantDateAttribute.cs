using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models.AnnotationsPersonnalisees
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AvantDateAttribute : ValidationAttribute
    {
        private readonly string _proprieteDeComparaison;

        public AvantDateAttribute(string proprieteDeComparaison)
        {
            _proprieteDeComparaison = proprieteDeComparaison;
        }

        protected override ValidationResult IsValid(object valeur, ValidationContext contexteValidation)
        {
            var infoPropriete = contexteValidation.ObjectType.GetProperty(_proprieteDeComparaison);

            if (infoPropriete == null)
            {
                return new ValidationResult($"Propriété inconnue : {_proprieteDeComparaison}");
            }

            var valeurComparaison = (DateTime)infoPropriete.GetValue(contexteValidation.ObjectInstance);

            if ((DateTime)valeur >= valeurComparaison)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
