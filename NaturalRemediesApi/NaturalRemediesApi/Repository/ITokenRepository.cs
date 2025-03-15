using Microsoft.AspNetCore.Identity;

namespace NaturalRemediesApi.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
