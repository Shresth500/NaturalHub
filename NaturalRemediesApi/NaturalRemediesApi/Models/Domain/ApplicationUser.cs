using Microsoft.AspNetCore.Identity;
using NaturalRemediesApi.Models.Domain;

namespace NaturalRemediesApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Carts> Carts { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
