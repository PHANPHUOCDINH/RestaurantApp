using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IStaffService _service;
        public AuthController(IConfiguration config, IStaffService service)
        {
            _config = config;
            _service = service;
        }

        //public AuthController(IStaffService service)
        //{
        //    _service = service;
        //}


        [AllowAnonymous]
        [HttpPost("signin")]
        public IActionResult CreateToken([FromBody] Staff login)
        {
            if (login == null) return Unauthorized();
            string tokenString = string.Empty;
            bool validUser = Authenticate(login.StaffUsername,login.StaffPassword);
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
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool Authenticate(string username,string password)
        {
            Staff user = _service.CheckLogIn(username,password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
