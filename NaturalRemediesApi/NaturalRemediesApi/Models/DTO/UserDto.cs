namespace NaturalRemediesApi.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CartDto> Carts { get; set; }
        public List<OrderDto> Order { get; set; }

    }
    public class OrderDto
    {
        public int Id { get; set; }
        public List<ProductDto> Products { get; set; }
    }
    public class ProductDto{
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
    public class CartDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

    }
}
