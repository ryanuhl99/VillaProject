using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIProject.Models.CreatedVillaNumberDTO
{
    public class CreatedVillaNumberDTO
    {

        [MaxLength(30)]
        public string SpecialDetails { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}