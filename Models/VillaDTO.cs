using System;
using RESTAPIProject.Validation.ValidationAttributes;
using RESTAPIProject.Controllers.VillaController;
using System.ComponentModel.DataAnnotations;

namespace RESTAPIProject.Models.VillaDTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public double? Rate { get; set; }
        public int? Sqft { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
    }
}