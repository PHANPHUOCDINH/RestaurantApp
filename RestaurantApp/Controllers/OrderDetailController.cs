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
    public class OrderDetailController:Controller
    {
        private readonly IOrderDetailService service;
        public OrderDetailController(IOrderDetailService service)
        {
            this.service = service;
        }

        [HttpGet(ApiRoute.GetAllOrderDetail)]
        public async Task<List<OrderDetail>> GetAllOrderDetail(string cookid)
        {
            return await service.GetAll(cookid);
        }

        [HttpGet(ApiRoute.GetAllOrderDetailByIdOrder)]
        public async Task<List<OrderDetail>> GetAllOrderDetailByIdOrder(string orderid)
        {
            return await service.GetAllByOrderId(orderid);
        }

        [HttpGet(ApiRoute.GetOrderDetailById)]
        public OrderDetail GetOrderDetailById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost(ApiRoute.AddOrderDetail)]
        public void AddOrderDetail([FromBody]OrderDetail orderdetail)
        {
            service.Insert(orderdetail);
        }

        [HttpPost(ApiRoute.DeleteOrderDetail)]
        public void DeleteOrderDetail(string id)
        {
            service.DeleteById(id);
        }

        [HttpPost(ApiRoute.UpdateCookRequest)]
        public void UpdateCookRequest([FromBody]OrderDetail od)
        {
            service.UpdateCookRequest(od);
        }

        [HttpPost(ApiRoute.UpdateStatus)]
        public void UpdateStatus([FromBody] OrderDetail od)
        {
            service.UpdateStatus(od);
        }
    }
}
