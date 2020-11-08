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

namespace RestaurantApp.Services.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext context;

        public AuthenticationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Staff Authenticate(string username, string password)
        {
            var user = (Staff)context.Staff.Where(x => x.StaffUsername == username && x.StaffPassword == password).FirstOrDefault();
            if (user == null)
                return null;
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("xxxx");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name,user.StaffId),
                        new Claim(ClaimTypes.Role,"Admin"),
                        new Claim(ClaimTypes.Version,"V3.1")

                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                //user.To
                return null;
            }

        }

    }
}
