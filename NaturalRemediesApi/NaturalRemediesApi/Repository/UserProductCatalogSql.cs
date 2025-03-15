using Microsoft.EntityFrameworkCore;
using NaturalRemediesApi.Data;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NaturalRemediesApi.Repository
{
    public class UserProductCatalogSql:IUserProductCatalog
    {
        private readonly ApplicationDbContext _context;
        public UserProductCatalogSql(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> BuyFromCartItem(string email)
        {
            var userData = await _context.Users.Include(a => a.Carts).ThenInclude(b => b.Products).Include(c => c.Orders).ThenInclude(d => d.OrderItems).ThenInclude(e => e.Products).Where(x =>  x.Email == email).FirstOrDefaultAsync();
            var orders = new Orders
            {
                ApplicationUserId = userData.Id,
                OrderItems = new List<OrderItems>()
            };
            await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
            foreach (var cart in userData.Carts) {
                var productdetails = await _context.Products.Where(x => x.Id == cart.ProductsId).FirstOrDefaultAsync();
                orders.OrderItems.Add(new OrderItems
                {
                    OrdersId = orders.Id,
                    ProductsId = cart.ProductsId,
                    Quantity = cart.Quantity,
                    Price = cart.Price
                });
            }
            _context.Carts.RemoveRange(userData.Carts);
            await _context.SaveChangesAsync();
            userData = await getUserByUserName(userData.UserName);
            return userData;
        }

        public async Task<ApplicationUser> BuyItem(string email, int ProductId, int quantity)
        {
            var productdetails = await _context.Products.Where(x => x.Id == ProductId).FirstOrDefaultAsync();
            if(quantity > productdetails.Quantity)
            {
                throw new Exception($"Quantity of {productdetails.Name} is less than the required quantity");
            }
            var data = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            var orders = new Orders
            {
                ApplicationUserId = data.Id,
                OrderItems = new List<OrderItems>()
            };
            await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
            var OrderItems = new OrderItems
            {
                OrdersId = orders.Id,
                ProductsId = ProductId,
                Quantity = quantity,
                Price = quantity*productdetails.Price,
            };
            productdetails.Quantity -= quantity;
            await _context.OrderItems.AddAsync(OrderItems);
            await _context.SaveChangesAsync();
            data = await _context.Users.Include(a => a.Carts).ThenInclude(b => b.Products).Include(c => c.Orders).ThenInclude(d => d.OrderItems).ThenInclude(e => e.Products).Where(x => x.Id == data.Id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<ApplicationUser> CartItems(string email, int ProductId, int quantity)
        {
            var productdetails = await _context.Products.Where(x => x.Id == ProductId).FirstOrDefaultAsync();
            if (quantity > productdetails.Quantity)
            {
                throw new Exception($"Quantity of {productdetails.Name} is less than the required quantity");
            }
            var data = await _context.Users.Where(x => x.Email == email).Include(y => y.Carts).ThenInclude(a => a.Products).Include(z => z.Orders).ThenInclude(c => c.OrderItems).ThenInclude(b => b.Products).FirstOrDefaultAsync();
            var carts = await _context.Carts.Where(x => x.ProductsId == ProductId && x.ApplicationUserId == data.Id).FirstOrDefaultAsync();
            if (carts == null)
            {
                carts = new Carts
                {
                    ApplicationUserId = data.Id,
                    ProductsId = ProductId,
                    Quantity = quantity,
                    Price = quantity * productdetails.Price,
                };
                await _context.AddAsync(carts);
            }
            else
            {
                carts.Quantity += quantity;
            }
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<ApplicationUser>> getListOfUser()
        {
            var data = await _context.Users.Include(x => x.Carts).Include(y => y.Orders).ThenInclude(z => z.OrderItems).ToListAsync();
            return data;
        }

        public async Task<ApplicationUser> getUserByUserName(string userName)
        {
            var data = await _context.Users.Where(a => a.UserName == userName).Include(x => x.Carts).ThenInclude(c => c.Products).Include(y => y.Orders).ThenInclude(z => z.OrderItems).ThenInclude(b => b.Products).FirstOrDefaultAsync();
            return data;

        }
    }
}
