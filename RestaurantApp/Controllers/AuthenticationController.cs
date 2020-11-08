using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class AuthenticationController:Controller
    {
        private readonly IAuthenticationService service;
        public AuthenticationController(IAuthenticationService service)
        {
            this.service = service;
        }
    }
}
