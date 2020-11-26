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
    [Authorize]
    public class BaoCaoController : Controller
    {
        private readonly IBaoCaoService service;
        public BaoCaoController(IBaoCaoService service)
        {
            this.service = service;

        }

        [HttpGet(ApiRoute.Top10BestSeller)]
        public async Task<List<Dish>> Top10BestSeller(int month, int year)
        {
            return await service.top10bestseller(month, year);
        }

        [HttpGet(ApiRoute.FoodFunds)]
        public decimal GetFoodFunds()
        {
            return service.foodBuying();
        }

        [HttpGet(ApiRoute.TotalOrder)]
        public decimal GetTotalOrder(int month)
        {
            return service.allOrderTotal(month);
        }

        [HttpGet(ApiRoute.TotalIncome)]
        public decimal GetTotalIncome(int month)
        {
            return service.totalIncome(month);
        }
    }
}
