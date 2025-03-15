using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NaturalRemediesApi.Models.DTO
{
    public class ProductsRequestDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Benefits { get; set; }
    }
}
