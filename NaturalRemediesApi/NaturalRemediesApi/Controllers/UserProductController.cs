using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.DTO;
using NaturalRemediesApi.Repository;
using System.Security.Claims;

namespace NaturalRemediesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductCatalog _userProductCatalog;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProductController(IUserProductCatalog userProductCatalog,UserManager<ApplicationUser> userManager)
        {
            _userProductCatalog = userProductCatalog;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser([FromQuery] string UserName)
        {
            var data = await _userProductCatalog.getUserByUserName(UserName);
            var result = new UserDto
            {
                Id = data.Id,
                Email = data.Email,
                Name = data.UserName,
                Carts = new List<CartDto>(),
                Order = new List<OrderDto>()
            };
            foreach (var cart in data.Carts) 
            {
                result.Carts.Add(new CartDto
                {
                    Id = cart.ProductsId,
                    Name = cart.Products.Name,
                    Quantity = cart.Quantity,
                    Price = cart.Price,
                });
            }
            foreach(var order in data.Orders)
            {
                List<ProductDto> productDtos = new List<ProductDto>();
                foreach(var orderItem in order.OrderItems)
                {
                    productDtos.Add(new ProductDto
                    {
                        Name = orderItem.Products.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Price,
                    });
                }
                result.Order.Add(new OrderDto { Id = order.Id,Products = productDtos });
            }
            return Ok(result);
        }

        [HttpPost("buy")]
        [Authorize]
        public async Task<IActionResult> BuyingProduct([FromBody] BuyDto Item)
        {
            string? email = User?.FindFirst(ClaimTypes.Email)?.Value;
            var data = await _userProductCatalog.BuyItem(email, Item.ProductId, Item.Quantity);
            var result = new UserDto
            {
                Id = data.Id,
                Email = email,
                Name = data.UserName,
                Carts = new List<CartDto>(),
                Order = new List<OrderDto>()
            };
            foreach (var cart in data.Carts)
            {
                result.Carts.Add(new CartDto
                {
                    Id = cart.ProductsId,
                    Name = cart.Products.Name,
                    Quantity = cart.Quantity,
                    Price = cart.Price,
                });
            }
            foreach (var order in data.Orders)
            {
                List<ProductDto> productDtos = new List<ProductDto>();
                foreach (var orderItem in order.OrderItems)
                {
                    productDtos.Add(new ProductDto
                    {
                        Name = orderItem.Products.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Price,
                    });
                }
                result.Order.Add(new OrderDto { Id = order.Id, Products = productDtos });
            }
            return Ok(result);
        }
        [HttpPost("AddToCart")]
        [Authorize]
        public async Task<IActionResult> AddToCart([FromBody] BuyDto Item)
        {
            string? email = User?.FindFirst(ClaimTypes.Email)?.Value;
            Item.Quantity = 1;
            var data = await _userProductCatalog.CartItems(email, Item.ProductId, Item.Quantity);
            var result = new UserDto
            {
                Id = data.Id,
                Email = email,
                Name = data.UserName,
                Carts = new List<CartDto>(),
                Order = new List<OrderDto>()
            };
            foreach (var cart in data.Carts)
            {
                result.Carts.Add(new CartDto
                {
                    Id = cart.ProductsId,
                    Name = cart.Products.Name,
                    Quantity = cart.Quantity,
                    Price = cart.Price,
                });
            }
            foreach (var order in data.Orders)
            {
                List<ProductDto> productDtos = new List<ProductDto>();
                foreach (var orderItem in order.OrderItems)
                {
                    productDtos.Add(new ProductDto
                    {
                        Name = orderItem.Products.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Price,
                    });
                }
                result.Order.Add(new OrderDto { Id = order.Id, Products = productDtos });
            }
            return Ok(result);
        }
        [HttpPost("Checkout")]
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            string? email = User?.FindFirst(ClaimTypes.Email)?.Value;
            var data = await _userProductCatalog.BuyFromCartItem(email);
            var result = new UserDto
            {
                Id = data.Id,
                Email = email,
                Name = data.UserName,
                Carts = new List<CartDto>(),
                Order = new List<OrderDto>()
            };
            foreach (var cart in data.Carts)
            {
                result.Carts.Add(new CartDto
                {
                    Id = cart.ProductsId,
                    Name = cart.Products.Name,
                    Quantity = cart.Quantity,
                    Price = cart.Price,
                });
            }
            foreach (var order in data.Orders)
            {
                List<ProductDto> productDtos = new List<ProductDto>();
                foreach (var orderItem in order.OrderItems)
                {
                    productDtos.Add(new ProductDto
                    {
                        Name = orderItem.Products.Name,
                        Quantity = orderItem.Quantity,
                        Price = orderItem.Price,
                    });
                }
                result.Order.Add(new OrderDto { Id = order.Id, Products = productDtos });
            }
            return Ok(result);
        }
    }
}
