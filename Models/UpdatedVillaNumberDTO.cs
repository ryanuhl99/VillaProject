using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIProject.Models.UpdatedVillaNumberDTO
{
    public class UpdatedVillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }

        [MaxLength(30)]
        public string SpecialDetails { get; set; }

    }
}