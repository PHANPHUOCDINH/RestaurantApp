using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Models;
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
        [HttpGet("getallorderdetail")]
        public List<OrderDetail> GetAllOrderDetail()
        {
            return service.GetAll();
        }

        [HttpGet("getallorderdetailbyidorder/{id?}")]
        public List<OrderDetail> GetAllOrderDetailByIdOrder(string id)
        {
            return service.GetAllByOrderId(id);
        }
        [HttpGet("getbyid/{id?}")]
        public OrderDetail GetOrderDetailById(string id)
        {
            return service.GetById(id);
        }

        [HttpPost("addorderdetail")]
        public void AddOrderDetail([FromBody] OrderDetail orderdetail)
        {
            service.Insert(orderdetail);
        }

        [HttpPost("deleteorderdetail/{id?}")]
        public void DeleteOrderDetail(string id)
        {
            service.DeleteById(id);
        }

        [HttpPost("updatecookrequest/{id?}/{cook_id?}/{starttime?}/{endtime?}")]
        public void UpdateCookRequest(string id, string cook_id,DateTime starttime,DateTime endtime)
        {
            service.UpdateCookRequest(id, cook_id, starttime, endtime);
        }

        [HttpPost("updatecookrequest/{id?}/{status?}")]
        public void UpdateStatus(string id, string status)
        {
            service.UpdateStatus(id, status);
        }
    }
}
