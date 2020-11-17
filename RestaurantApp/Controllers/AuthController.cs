using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenservice;
        private readonly IStaffService _staffservice;
        public AuthController(IConfiguration config,IStaffService staffService,ITokenService tokenService,ApplicationDbContext context)
        {
            _config = config;
            _staffservice = staffService;
            _tokenservice = tokenService;
            _context = context;
        }

        //[HttpPost, Route("login")]
        //public IActionResult Login([FromBody] Staff loginModel)
        //{
        //    if (loginModel == null)
        //    {
        //        return BadRequest("Invalid client request");
        //    }
        //    Staff user = new Staff();
        //    //Staff user = _staffservice.CheckLogIn(loginModel.StaffUsername, loginModel.StaffPassword);
        //    if (loginModel.StaffPassword != "admin"  || loginModel.StaffUsername !="admin")
        //    {
        //        return Unauthorized();
        //    }
        //    var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, loginModel.StaffUsername),
        //    new Claim(ClaimTypes.Role, "Manager")
        //};
        //    var accessToken = _tokenservice.GenerateAccessToken(claims);
        //    var refreshToken = _tokenservice.GenerateRefreshToken();
        //    user.RefreshToken = refreshToken;
        //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

        //  //  _context.SaveChanges();
        //    return Ok(new
        //    {
        //        Token = accessToken,
        //        RefreshToken = refreshToken
        //    });
        //}
        //public AuthController(IStaffService service)
        //{
        //    _service = service;
        //}

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] Staff login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            //bool validUser = Authenticate(login.StaffUsername, login.StaffPassword);
            var user = _context.Staff
            .FirstOrDefault(u => (u.StaffUsername == login.StaffUsername) &&
                                    (u.StaffPassword == login.StaffPassword));
            if (user == null)
            {
                return Unauthorized();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.StaffUsername),
                new Claim(ClaimTypes.Role, user.RoleId)
            };
            //var accessToken = _tokenservice.GenerateAccessToken(claims);
            var accessToken = _tokenservice.GenerateAccessToken(claims);
             var refreshToken = _tokenservice.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.AccessToken = accessToken;
            _context.SaveChanges();
            return Ok(new { Token = accessToken,
                RefreshToken = refreshToken

            });

        }


        //private string BuildToken()
        //{
        //    var jwtSettings = new JwtSettings();
        //    _config.Bind(nameof(jwtSettings), jwtSettings);
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        jwtSettings.Issuer,
        //        jwtSettings.Issuer,
        //        expires: DateTime.UtcNow.AddMinutes(10),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        //private string BuildRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}

        private bool Authenticate(string username, string password)
        {
            //Staff user = _staffservice.CheckLogIn(username, password);
            //if (user != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return _staffservice.CheckLogIn(username, password);
        }

        //[HttpPost]
        //[Route("refresh")]
        //public IActionResult Refresh(TokenApiModel tokenApiModel)
        //{
        //    if (tokenApiModel is null)
        //    {
        //        return BadRequest("Invalid client request");
        //    }
        //    string accessToken = tokenApiModel.AccessToken;
        //    string refreshToken = tokenApiModel.RefreshToken;
        //    var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
        //    var username = principal.Identity.Name; //this is mapped to the Name claim by default
        //    var user = userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
        //    if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        //    {
        //        return BadRequest("Invalid client request");
        //    }
        //    var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
        //    var newRefreshToken = tokenService.GenerateRefreshToken();
        //    user.RefreshToken = newRefreshToken;
        //    userContext.SaveChanges();
        //    return new ObjectResult(new
        //    {
        //        accessToken = newAccessToken,
        //        refreshToken = newRefreshToken
        //    });
        //}
        //[HttpPost, Authorize]
        //[Route("revoke")]
        //public IActionResult Revoke()
        //{
        //    var username = User.Identity.Name;
        //    var user = userContext.LoginModels.SingleOrDefault(u => u.UserName == username);
        //    if (user == null) return BadRequest();
        //    user.RefreshToken = null;
        //    userContext.SaveChanges();
        //    return NoContent();
        //}
    }
}
