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
    public class OrderController : Controller
    {
        private readonly IOrderService service;
        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet(ApiRoute.GetAllOrderAsync)]
        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await service.GetAll();
        }

        [HttpGet(ApiRoute.GetOrderById)]
        public Order GetOrderById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost(ApiRoute.AddOrder)]
        public IActionResult AddOrder([FromBody] Order order)
        {
            return Ok(new { Id = service.Insert(order) });
        }

        [HttpPost(ApiRoute.UpdateOrder)]
        public void UpdateOrder([FromBody] Order order)
        {
            service.Update(order);
        }

        [HttpPost(ApiRoute.DeleteOrder)]
        public void DeleteOrder(string id)
        {
            service.DeleteById(id);
        }
    }
}
