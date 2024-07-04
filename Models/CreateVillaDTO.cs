using System;
using System.ComponentModel.DataAnnotations;
using RESTAPIProject.Validation.ValidationAttributes;

namespace RESTAPIProject.Models.CreateVillaDTO
{
    public class CreateVillaRequest
    {
        [Required]
        [MaxLength(15)]
        [MinLength(6)]
        [NonNumericSymbolic]
        public string? Name { get; set; }
    }
}