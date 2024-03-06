using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models.AnnotationsPersonnalisees
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FuturDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = (DateTime)value;
            return dateTime > DateTime.Now;
        }
    }
}
