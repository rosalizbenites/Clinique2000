using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinique2000_Models.ViewModels
{
    public class RechercheCliniquesVM
    {
        public List<ResultatsCliniquesVM> Resultats { get; set; }
        public string? LatitudeUtilisateur { get; set; }
        public string? LongitudeUtilisateur { get; set; }
        public string? Erreur { get; set; }
    }
}
