using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models
{
    public class DateRangeAttribute: ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime? dateValue = value as DateTime?;

                if (dateValue == null)
                {
                    // Handle the case where the date is not provided (null)
                    return ValidationResult.Success; // Change this if necessary
                }

                // Your custom date range validation logic goes here
                DateTime minDate = DateTime.Now.AddYears(-120);
                DateTime maxDate = DateTime.Now.AddYears(-18);

                if (dateValue < minDate || dateValue > maxDate)
                {
                    return new ValidationResult($"Le patient doit être majeur de 18 ans ou née entre {minDate.ToShortDateString()} et {maxDate.ToShortDateString()}.");
                }

                return ValidationResult.Success;
            }
    }
    
}
