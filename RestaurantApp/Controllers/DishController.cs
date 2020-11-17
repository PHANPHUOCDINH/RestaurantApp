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
    public class DishController : Controller
    {
        private readonly IDishService service;
        public DishController(IDishService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(ApiRoute.GetAllDishAsync)]
        public async  Task<List<Dish>> GetAllDish()
        {
            return await service.GetAllDish();
        }

        [Authorize]
        [HttpPost(ApiRoute.AddDish)]
        public void AddDish([FromBody] Dish dish)
        {
            service.Insert(dish);
        }

        [Authorize]
        [HttpGet(ApiRoute.GetDishById)]
        public Dish GetDishById(string id)
        {
            return service.GetById(id);
        }

        [Authorize]
        [HttpPut(ApiRoute.UpdateDish)]
        public void UpdateDish([FromBody] Dish dish)
        {
            service.Update(dish);
        }

        [Authorize]
        [HttpDelete(ApiRoute.DeleteDish)]
        public void DeleteDish(string id)
        {
            service.DeleteById(id);
        }

    }
}
