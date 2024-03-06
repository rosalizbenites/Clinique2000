using Azure.Maps.Search;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Maps.Search.Models;
using Clinique2000_DataAccess.Data;
using Microsoft.AspNetCore.Identity;
using Clinique2000_Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Clinique2000_Services.Services.IServices;

namespace Clinique2000_Services.Services
{
    public class AzureMapsService : IAzureMapsService
    {
        // Méthode pour obtenir les coordonnées géographiques (latitude, longitude) d'un code postal
        public GeoPosition ObtenirCoordonnees(string codePostal)
        {
            // Instanciation du client AzureMapsSearch
            // Voir ce guide au besoin: https://learn.microsoft.com/en-us/azure/azure-maps/how-to-dev-guide-csharp-sdk
            string subscriptionKey = "BV5AOeBWZU9njABDhnisf3zdg4ViAhY8DBWyIIc-GSw";
            AzureKeyCredential credential = new AzureKeyCredential(subscriptionKey);
            MapsSearchClient client = new MapsSearchClient(credential);

            GeoPosition coordonnees;

            // Exemple: Clinique de la Santé (clinique d'Édouard-Montpetit) de code postal "J4H 3M6"
            SearchAddressResult searchResult = client.SearchAddress(codePostal);

            if (searchResult.Results.Count > 0)
            {
                SearchAddressResultItem result = searchResult.Results.First();

                // Instanciation des coordonnées latitude/longitude correspondant au code postal
                coordonnees = new GeoPosition(result.Position.Longitude, result.Position.Latitude);

                return coordonnees;
            }

            // Instanciation de coordonnées de latitude 0° et de longitude 0° si un problème survient avec SearchAddress
            coordonnees = new GeoPosition();

            return coordonnees;
        }

        // Méthode pour calculer la distance entre un patient et une clinique en utilisant la formule de Haversine.
        public double CalculerDistance(User userCourant, Clinique clinique)
        {
            return CalculerDistance((double)userCourant.Latitude, (double)userCourant.Longitude, clinique.Latitude, clinique.Longitude);
        }

        // Méthode pour calculer la distance entre deux points géographiques en utilisant la formule de Haversine.
        public double CalculerDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            const double R = 6371; // Rayon de la Terre en kilomètres

            // Convertir la latitude et la longitude de degrés à radians
            latitude1 = EnRadians(latitude1);
            longitude1 = EnRadians(longitude1);
            latitude2 = EnRadians(latitude2);
            longitude2 = EnRadians(longitude2);

            // Calculer les différences
            double differenceLat = latitude2 - latitude1;
            double differenceLon = longitude2 - longitude1;

            // Formule de Haversine
            double a = Math.Pow(Math.Sin(differenceLat / 2), 2) + Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Pow(Math.Sin(differenceLon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Calculer la distance
            double distance = R * c;

            return distance;
        }

        // Méthode pour convertir un angle de degrés à radians
        private double EnRadians(double angle)
        {
            return angle * (Math.PI / 180);
        }

        // Méthode pour trier les cliniques selon la distance entre l'utilisateur courant et les cliniques
        // Note: Retourne seulement les 5 cliniques les plus près du patient
        public List<Clinique> TrierCliniquesSelonDistance(User userCourant, List<Clinique> cliniques)
        {
            return cliniques.
                OrderBy(clinique => CalculerDistance((double)userCourant.Latitude, (double)userCourant.Longitude, clinique.Latitude, clinique.Longitude)).
                Take(5).
                ToList();
        }

        // Méthode pour obtenir une liste des distances entre l'utilisateur courant et les cliniques
        public List<double> ObtenirDistances(User userCourant, List<Clinique> cliniques)
        {
            List<double> resultat = new List<double>();

            foreach (Clinique clinique in cliniques)
            {
                resultat.Add(CalculerDistance(userCourant, clinique));
            }

            return resultat;
        }
    }
}
