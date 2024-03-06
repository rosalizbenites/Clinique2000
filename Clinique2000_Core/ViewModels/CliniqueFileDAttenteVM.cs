using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Models.ViewModels
{
    public class CliniqueFileDAttenteVM
    {
        public Clinique cliniqueCourante { get; set; }
        public FileDAttente? fileDAttenteActive { get; set; }
    }
}
