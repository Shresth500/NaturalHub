using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalRemediesApi.Models.Domain
{
    public class HealthTips
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipId { get; set; }
        [Required]
        [StringLength(1000)]
        public string TipName { get; set; }

        public int DiseaseId { get; set; }
        public Diseases Diseases { get; set; }
    }
}
