using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRole();
    }
}
