using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaturalRemediesApi.Models.DTO;
using NaturalRemediesApi.Repository;

namespace NaturalRemediesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepo _products;
        private readonly IMapper _mapper;
        
        public ProductsController(IProductsRepo products,IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getProducts()
        {
            var data = await _products.GetProducts();
            var result = _mapper.Map<List<ProductsResponseDto>>(data);
            return Ok(result);
        }
        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> getProductById([FromQuery] string ProductName)
        {
            var data = await _products.GetProductsByName(ProductName);
            var result = _mapper.Map<List<ProductsResponseDto>>(data);
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> getProductById([FromRoute] int id)
        {
            var data = await _products.GetProductsById(id);
            var result = _mapper.Map<ProductsResponseDto>(data);
            return Ok(result);
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> PostProducts([FromBody] ProductsRequestDto productsRequestDto)
        {
            var data = await _products.PostProduct(productsRequestDto);
            var result = _mapper.Map<ProductsResponseDto>(data);
            return Ok(result);
        }
        [HttpPut("{id:int}")]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductsRequestDto productsRequestDto)
        {
            var data = await _products.UpdateProducts(id, productsRequestDto);
            var result = _mapper.Map<ProductsResponseDto>(data);
            return Ok(result);
        }
    }
}
