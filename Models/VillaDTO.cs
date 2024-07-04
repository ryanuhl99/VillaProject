using System;
using RESTAPIProject.Validation.ValidationAttributes;
using RESTAPIProject.Controllers.VillaController;
using System.ComponentModel.DataAnnotations;

namespace RESTAPIProject.Models.VillaDTO
{
    public class VillaDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        [NonNumericSymbolic]
        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}