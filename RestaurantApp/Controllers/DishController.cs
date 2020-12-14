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
    public class DishController : Controller
    {
        private readonly IDishService service;
        public DishController(IDishService service)
        {
            this.service = service;

        }

        [HttpGet(ApiRoute.GetAllDishAsync)]
        public async Task<List<Dish>> GetAllDish(bool isactive)
        {
            return await service.GetAllDish(isactive);
        }

        [HttpPost(ApiRoute.AddDish)]
        public IActionResult AddDish([FromBody] Dish dish)
        {
            return Ok(new { Id = service.Insert(dish) });
        }

        [HttpGet(ApiRoute.GetDishById)]
        public Dish GetDishById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost(ApiRoute.UpdateDish)]
        public void UpdateDish([FromBody] Dish dish)
        {
            service.Update(dish);
        }

        [HttpPost(ApiRoute.DeleteDish)]
        public void DeleteDish(string id)
        {
            service.DeleteById(id);
        }

    }
}
