using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelResultViewModel
    {

        public string SelectedPlanet { get; set; }

        public string SelectedModeOfTransportation { get; set; }

        public int EarthAge { get; set; }

        public double AgeOncePlanetReached { get; set; }

        public double NumOfYearsToPlanet { get; set; }

        public Dictionary<string, int> TransportationSpeeds = new Dictionary<string, int>()
        {
            { "Walking", 3 },
            { "Car", 100 },
            { "Bullet Train", 200 },
            { "Boeing 747", 570 },
            { "Concorde", 1350 }

        };

        public Dictionary<string, long> AvgDistToPlanets = new Dictionary<string, long>()
        {
            { "Mercury", 56974146 },
            { "Venus", 25724767 },
            { "Earth", 0 },
            { "Mars", 48678219 },
            { "Jupiter", 390674710 },
            { "Saturn", 792248270 },
            { "Uranus", 1692662530 },
            { "Neptune", 2703959960 }

        };

        public AlienTravelResultViewModel(string selectedPlanet, string selectedTransportation, int earthAge)
        {
            SelectedPlanet = selectedPlanet;

            SelectedModeOfTransportation = selectedTransportation;

            EarthAge = earthAge;

            SetProperties();
        }


        private void SetProperties()
        {
            YearsToPlanetFromEarth(SelectedPlanet, SelectedModeOfTransportation);

            CalcAgePlanetReached();
        }

        private void YearsToPlanetFromEarth(string SelectedPlanet, string SelectedTransportation)
        {
            const int hoursInOneYear = 8760;

            double hoursToPlanet = AvgDistToPlanets[SelectedPlanet] / TransportationSpeeds[SelectedTransportation];
            
            NumOfYearsToPlanet = hoursToPlanet / hoursInOneYear;
        }

        private void CalcAgePlanetReached()
        {
            AgeOncePlanetReached = EarthAge + NumOfYearsToPlanet;
        }
    }
}
