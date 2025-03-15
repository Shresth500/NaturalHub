namespace NaturalRemediesApi.Models.Domain
{
    public class OrderItems
    {
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }

        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
