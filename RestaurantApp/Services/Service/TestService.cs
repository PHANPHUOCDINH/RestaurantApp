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
    public class TestService: ITestService
    {
        private readonly ApplicationDbContext context;
        public TestService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Test>> GetAllTestAsync()
        {
            return await context.Test.ToListAsync();
        }
    }
}
