using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IBaoCaoService
    {
        Task<List<Dish>> top10bestseller(int month, int year);
    }
}
