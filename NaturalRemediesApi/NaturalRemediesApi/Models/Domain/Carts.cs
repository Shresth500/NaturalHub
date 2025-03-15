namespace NaturalRemediesApi.Models.Domain
{
    public class Carts
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
