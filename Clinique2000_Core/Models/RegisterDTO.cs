using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.Models
{
    public class RegisterDTO
    {
        public int? Id { get; set; }

        [Display(Name = "Username")]
        [StringLength(100)]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "PasswordConfirm")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les deux mots de passe spécifiés sont différents.")]
        public string PasswordConfirm { get; set; }
    }
}
