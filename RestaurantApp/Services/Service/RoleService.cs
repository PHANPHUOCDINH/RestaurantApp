using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Service
{
    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext context;
        public RoleService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Role>> GetAllRole()
        {
            return await context.Role.ToListAsync();
        }

        public Role GetById(string id)
        {
            var obj = context.Role.Where(x => x.RoleId == id).FirstOrDefault();
            return (Role)obj;
        }
    }
}
