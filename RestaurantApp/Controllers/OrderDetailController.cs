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
    public class OrderDetailController:Controller
    {
        private readonly IOrderDetailService service;
        public OrderDetailController(IOrderDetailService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet(ApiRoute.GetAllOrderDetail)]
        public async Task<List<OrderDetail>> GetAllOrderDetail(string cookid)
        {
            return await service.GetAll(cookid);
        }

        [Authorize]
        [HttpGet(ApiRoute.GetAllOrderDetailByIdOrder)]
        public async Task<List<OrderDetail>> GetAllOrderDetailByIdOrder(string orderid)
        {
            return await service.GetAllByOrderId(orderid);
        }

        [Authorize]
        [HttpGet(ApiRoute.GetOrderDetailById)]
        public OrderDetail GetOrderDetailById(string id)
        {
            return service.GetById(id);
        }

        [Authorize]
        [HttpPost(ApiRoute.AddOrderDetail)]
        public void AddOrderDetail([FromBody]OrderDetail orderdetail)
        {
            service.Insert(orderdetail);
        }

        [Authorize]
        [HttpDelete(ApiRoute.DeleteOrderDetail)]
        public void DeleteOrderDetail(string id)
        {
            service.DeleteById(id);
        }

        [Authorize]
        [HttpPut(ApiRoute.UpdateCookRequest)]
        public void UpdateCookRequest([FromBody]OrderDetail od)
        {
            service.UpdateCookRequest(od);
        }

        //[Authorize]
        [HttpPut(ApiRoute.UpdateStatus)]
        public void UpdateStatus([FromBody] OrderDetail od)
        {
            service.UpdateStatus(od);
        }
    }
}
