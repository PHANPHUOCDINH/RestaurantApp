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
        public async Task<List<OrderDetail>> GetAllOrderDetailByIdOrder(string id)
        {
            return await service.GetAllByOrderId(id);
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
        [HttpPost(ApiRoute.DeleteOrderDetail)]
        public void DeleteOrderDetail(string id)
        {
            service.DeleteById(id);
        }

        [Authorize]
        [HttpPost(ApiRoute.UpdateCookRequest)]
        public void UpdateCookRequest(string id, string cook_id,DateTime starttime,DateTime endtime)
        {
            service.UpdateCookRequest(id, cook_id, starttime, endtime);
        }

        [Authorize]
        [HttpPost(ApiRoute.UpdateStatus)]
        public void UpdateStatus(string id, int status)
        {
            service.UpdateStatus(id, status);
        }
    }
}
