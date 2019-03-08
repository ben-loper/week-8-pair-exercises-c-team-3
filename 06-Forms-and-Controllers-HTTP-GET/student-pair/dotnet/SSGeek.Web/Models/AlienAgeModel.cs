using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
        [Display(Name = "Choose a planet")]
        public string SelectedPlanet { get; set; }

        [Display(Name = "Enter your Earth age")]
        public double EarthAge { get; set; }

        public static List<SelectListItem> Planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury", Value = "Mercury" },
            new SelectListItem() { Text = "Venus", Value = "Venus" },
            new SelectListItem() { Text = "Earth", Value = "Earth" },
            new SelectListItem() { Text = "Mars", Value = "Mars" },
            new SelectListItem() { Text = "Jupiter", Value = "Jupiter" },
            new SelectListItem() { Text = "Saturn", Value = "Saturn" },
            new SelectListItem() { Text = "Uranus", Value = "Uranus" },
            new SelectListItem() { Text = "Neptune", Value = "Neptune" },
            new SelectListItem() { Text = "Pluto", Value = "Pluto" }

        };

//        Mercury	87.96 Earth days
    //Venus	224.68 Earth days
    //Earth	365.26 Earth days
    //Mars	686.98 Earth days
    //Jupiter	11.862 Earth years
    //Saturn	 Earth years
    //Uranus	84.07 Earth years
    //Neptune	164.81 Earth years
//Pluto(a dwarf planet)  247.7 Earth years

        private static Dictionary<string, double> _yearsToCirlceSunInEarthYears = new Dictionary<string, double>()
        {
            { "Mercury", 0.24081476208728029348956907408421 },
            { "Venus", 0.61512347368997426490718939933198 },
            { "Earth", 1 },
            { "Mars", 1.8807972403219624377155998466846 },
            { "Jupiter", 11.862 },
            { "Saturn", 29.456 },
            { "Uranus", 84.07 },
            { "Neptune", 164.81 },
            { "Pluto", 247.7 }
        };


        public static double CalcAlienAge(string planet, double currentAge)
        {
            
            return currentAge / _yearsToCirlceSunInEarthYears[planet];
        }
    }
}
