using System;
using System.ComponentModel.DataAnnotations;
using RESTAPIProject.Validation.ValidationAttributes;
using Microsoft.EntityFrameworkCore;

namespace RESTAPIProject.Models.CreateVillaDTO
{
    public class CreateVillaRequest
    {
        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        [NonNumericSymbolic]
        public string Name { get; set; }

        [Range (1, 100)]
        public int Occupancy { get; set; }

        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}