using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelModel
    {
        [Display(Name = "Choose a planet")]
        public string SelectedPlanet  { get; set; }

        [Display(Name = "Choose a mode of transport")]
        public string SelectedModeOfTransportation { get; set; }

        [Display(Name = "Enter your Earth age")]
        public int EarthAge { get; set; }

        public static List<SelectListItem> ModesOfTransportation = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value = "Walking" },
            new SelectListItem() { Text = "Car", Value = "Car" },
            new SelectListItem() { Text = "Bullet Train", Value = "Bullet Train" },
            new SelectListItem() { Text = "Boeing 747", Value = "Boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "Concorde" },
            
        };

        public static List<SelectListItem> AvgDistToPlanets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury", Value = "Mercury" },
            new SelectListItem() { Text = "Venus", Value = "Venus" },
            new SelectListItem() { Text = "Earth", Value = "Earth" },
            new SelectListItem() { Text = "Mars", Value = "Mars" },
            new SelectListItem() { Text = "Jupiter", Value = "Jupiter" },
            new SelectListItem() { Text = "Saturn", Value = "Saturn" },
            new SelectListItem() { Text = "Uranus", Value = "Uranus" },
            new SelectListItem() { Text = "Neptune", Value = "Neptune" }

        };
    }
}
