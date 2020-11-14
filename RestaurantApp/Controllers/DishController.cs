using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
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

        //[Authorize]
        [HttpGet("getalldish")]
        public List<Dish> GetAllDishAsync()
        {
            return service.GetAllDishAsync();
        }

        [HttpPost("adddish")]
        public void AddDish([FromBody] Dish dish)
        {
            service.Insert(dish);
        }

        [HttpGet("getdishbyid/{id?}")]
        public Dish GetDishById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost("updatedish")]
        public void UpdateDish([FromBody] Dish dish)
        {
            service.Update(dish);
        }

        [HttpPost("deletedish/{id?}")]
        public void DeleteDish(string id)
        {
            service.DeleteById(id);
        }

        [HttpGet("alalalal")]
        public async Task<IActionResult> GetAllAsync()
        {
            //return Ok(await service.GetAllAsync());
            var a = HttpContext.RequestServices.GetService(typeof(ITableService)) as ITableService;
            return Ok(await a.GetAllTableAsync());
        }
    }
}
