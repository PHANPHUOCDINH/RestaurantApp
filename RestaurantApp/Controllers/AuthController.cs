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
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
       // private readonly ApplicationDbContext _context;
       // private readonly ITokenService _tokenservice;
        private readonly IStaffService _staffservice;
        public AuthController(IConfiguration config,IStaffService staffService)
        {
            _config = config;
            _staffservice = staffService;
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
        public IActionResult CreateToken([FromBody] Staff login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(login.StaffUsername, login.StaffPassword);
            if (validUser)
            {
                tokenString = BuildToken();
            }
            else
            {
                return Unauthorized();
            }
            return Ok(new { Token = tokenString });
        }


        private string BuildToken()
        {
            var jwtSettings = new JwtSettings();
            _config.Bind(nameof(jwtSettings), jwtSettings);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Issuer,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

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

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
