using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models.AnnotationsPersonnalisees
{
    public class UserDateAttribute : RangeAttribute
    {
        public UserDateAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-120).ToShortDateString(),
                  DateTime.Now.AddYears(-18).ToShortDateString())
        { }

    }
    
}
