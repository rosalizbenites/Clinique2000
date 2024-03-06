using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clinique2000_Models.ViewModels
{
    public class ResultatsCliniquesVM
    {
        public Clinique Clinique { get; set; }
        [Display(Name = "Distance")]
        [JsonIgnore]
        public double Distance { get; set; }
        [Display(Name = "Prochain rendez-vous")]
        [JsonIgnore]
        public TimeSpan? HeureProchainePlagesHoraireDisponible { get; set; }
    }
}
