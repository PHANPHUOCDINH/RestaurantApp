using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class TokenController:Controller
    {
        readonly ApplicationDbContext _context;
        readonly ITokenService tokenService;
        public TokenController(ApplicationDbContext context, ITokenService tokenService)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody]Token tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }
            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _context.Staff.SingleOrDefault(u => u.StaffUsername == username);
            if (user == null || user.RefreshToken != refreshToken)
            {
                return BadRequest("Invalid client request zz");
            }
            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var user = _context.Staff.SingleOrDefault(u => u.StaffUsername == username);
            if (user == null) return BadRequest();
            //   user.RefreshToken = null;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
