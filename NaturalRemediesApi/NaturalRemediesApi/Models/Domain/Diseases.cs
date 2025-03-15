using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NaturalRemediesApi.Models.Domain;

namespace NaturalRemediesApi.Models
{
    public class Diseases
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }   
        
        public List<Remedies> Remedies { get; set; }
        public List<HealthTips> HealthTips { get; set; }

        public string Description { get; set; }
        public string Benefits { get; set; }
        public string Preparation { get; set; }
        public string Usage { get; set; }
    }
}
