using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claim);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
