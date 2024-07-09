using System;
using System.ComponentModel.DataAnnotations;
using RESTAPIProject.Validation.ValidationAttributes;

namespace RESTAPIProject.Models.UpdateVillaDTO
{
    public class UpdateVillaRequest
    {
        [Required]
        public int Id { get; set;}

        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        [NonNumericSymbolic]
        public string? Name { get; set; }

        [Range (1, 100)]
        public int? Occupancy { get; set; }

        [MaxLength(30)]
        public string? Details { get; set; }

        [Required]
        public double? Rate { get; set; }

        [Required]
        [Range (1, int.MaxValue)]
        public int? Sqft { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }

    }
}