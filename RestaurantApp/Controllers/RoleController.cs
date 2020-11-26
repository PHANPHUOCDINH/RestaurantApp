using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using RestaurantApp.Route;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class RoleController: Controller
    {
        private readonly IRoleService service;
        public RoleController(IRoleService service)
        {
            this.service = service;
        }
        [Authorize]
        [HttpGet(ApiRoute.GetAllRoleAsync)]
        public async Task<List<Role>> GetAllRoles()
        {
            return await service.GetAllRole();
        }
    }
}
