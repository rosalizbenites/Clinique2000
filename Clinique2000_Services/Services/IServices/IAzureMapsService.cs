using Azure.Core.GeoJson;
using Clinique2000_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinique2000_Services.Services.IServices
{
    public interface IAzureMapsService
    {
        public GeoPosition ObtenirCoordonnees(string codePostal);
        public double CalculerDistance(User userCourant, Clinique clinique);
        public double CalculerDistance(double latitude1, double longitude1, double latitude2, double longitude2);
        public List<Clinique> TrierCliniquesSelonDistance(User userCourant, List<Clinique> cliniques);
        public List<double> ObtenirDistances(User userCourant, List<Clinique> cliniques);
    }
}
