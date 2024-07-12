using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIProject.Models.CreatedVillaNumberDTO
{
    public class CreatedVillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }

        [MaxLength(30)]
        public string SpecialDetails { get; set; }

    }
}