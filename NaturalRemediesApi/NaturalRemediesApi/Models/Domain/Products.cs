using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalRemediesApi.Models.Domain
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description {  get; set; }
        public string Benefits { get; set; }
        public List<Carts> Carts { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
