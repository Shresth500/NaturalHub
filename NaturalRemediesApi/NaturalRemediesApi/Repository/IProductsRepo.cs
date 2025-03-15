using NaturalRemediesApi.Models.Domain;
using NaturalRemediesApi.Models.DTO;

namespace NaturalRemediesApi.Repository
{
    public interface IProductsRepo
    {
        public Task<List<Products>> GetProducts();
        public Task<List<Products>> GetProductsByName(string ProductName);
        public Task<Products> GetProductsById(int id);
        public Task<Products> PostProduct(ProductsRequestDto productRequest);
        public Task<Products> UpdateProducts(int id,ProductsRequestDto productRequest);
    }
}

