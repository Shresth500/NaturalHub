using Microsoft.AspNetCore.Mvc.ActionConstraints;
using NaturalRemediesApi.Models;

namespace NaturalRemediesApi.Repository
{
    public interface IUserProductCatalog
    {
        public Task<List<ApplicationUser>> getListOfUser();
        public Task<ApplicationUser> getUserByUserName(string userName);
        public Task<ApplicationUser> BuyItem(string email,int ProductId, int quantity);
        public Task<ApplicationUser> CartItems(string email,int ProductId, int quantity);
        public Task<ApplicationUser> BuyFromCartItem(string email);
    }
}
