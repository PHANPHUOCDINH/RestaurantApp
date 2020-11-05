using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrderService service;
        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet("getallorder")]
        public List<Order> GetAllOrderAsync()
        {
            return service.GetAll();
        }

        [HttpGet("getorderbyid/{id?}")]
        public Order GetOrderById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost("addorder")]
        public void AddOrder([FromBody] Order order)
        {
            service.Insert(order);
        }

        [HttpPost("updateorder")]
        public void UpdateOrder([FromBody] Order order)
        {
            service.Update(order);
        }

        [HttpPost("deleteorder/{id?}")]
        public void DeleteOrder(string id)
        {
            service.DeleteById(id);
        }
    }
}
