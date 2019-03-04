using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        public string SelectedPlanet { get; set; }

        public double EarthWeight { get; set; }

        public static Dictionary<string, double> AccDueToGrav = new Dictionary<string, double>()
        {
            { "Sun", 274.13 },
            { "Mercury", 3.59 },
            { "Venus", 8.87 },
            { "Earth", 9.81},
            {"Moon", 1.62 },
            { "Mars", 3.77 },
            {"Jupiter", 25.95 },
            { "Saturn", 11.08 },
            { "Uranus", 10.67 },
            { "Neptune", 10.67 },
            { "Pluto", 0.42 }
        };

        public static List<SelectListItem> Planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Sun", Value = "Sun" },
            new SelectListItem() { Text = "Mercury", Value = "Mercury" },
            new SelectListItem() { Text = "Venus", Value = "Venus" },
            new SelectListItem() { Text = "Earth", Value = "Earth" },
            new SelectListItem() { Text = "Saturn", Value = "Saturn" }
        };

        public static double CalcAlienWeight(string planet, double earthWeight)
        {
            double result = 0;

            double planetG = AccDueToGrav[planet];

            double mass = earthWeight/ AccDueToGrav["Earth"];

            result = mass * planetG;

            return result;
        }
    }
}