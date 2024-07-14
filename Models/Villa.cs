using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RESTAPIProject.Validation.ValidationAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIProject.Models.VillaClass
{
    [Index(nameof(Name), IsUnique = true)]
    public class Villa
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}