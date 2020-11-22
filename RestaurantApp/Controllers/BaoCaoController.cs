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
    public class BaoCaoController:Controller
    {
        private readonly IBaoCaoService service;
        public BaoCaoController(IBaoCaoService service)
        {
            this.service = service;

        }

       //Authorize]
        [HttpGet(ApiRoute.Top10BestSeller)]
        public async Task<List<Dish>> Top10BestSeller(int month,int year)
        {
            return await service.top10bestseller(month,year);
        }
    }
}
