using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RESTAPIProject.Models.VillaClass;

namespace RESTAPIProject.Models.VillaNumber
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(100, int.MaxValue)]
        public int VillaNo { get; set; }

        [MaxLength(30)]
        public string SpecialDetails { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [ForeignKey("Villa")]
        public int VillaID { get; set; }
        public Villa Villa { get; set; }
    }
}