using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface ITestService
    {
        Task<List<Test>> GetAllTestAsync();
    }
}
