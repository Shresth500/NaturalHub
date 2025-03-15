using Microsoft.EntityFrameworkCore;
using NaturalRemediesApi.Data;
using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public class ProductsSql : IProductsRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductsSql(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetProducts()
        {
            var data = await _context.Products.ToListAsync();
            return data;
        }

        public async Task<Products> GetProductsById(int Id)
        {
            var data = await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<Products>> GetProductsByName(string ProductName)
        {
            var data = await _context.Products.Where(x => x.Name.Contains(ProductName)).ToListAsync();
            return data;
        }

        public async Task<Products> PostProduct(ProductsRequestDto productRequest)
        {
            await _context.Products.AddAsync(new Products
            {
                Name = productRequest.Name,
                Quantity = productRequest.Quantity,
                Benefits = productRequest.Benefits,
                Description = productRequest.Description,
                Price = productRequest.Price,
                Carts = new List<Carts>(),
                OrderItems = new List<OrderItems>(),
            });
            await _context.SaveChangesAsync();
            var data = await _context.Products.Where(x => x.Name == productRequest.Name).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Products> UpdateProducts(int id, ProductsRequestDto productRequest)
        {
            var data = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            data.Benefits = productRequest.Benefits;
            data.Price = productRequest.Price;
            data.Quantity = productRequest.Quantity;
            data.Description = productRequest.Description;
            data.Name = productRequest.Name;
            await _context.SaveChangesAsync();
            data = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data;
        }
    }
}
