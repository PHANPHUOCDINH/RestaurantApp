using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IOrderDetailService
    {
        void Insert(OrderDetail orderdetail);

        Task<List<OrderDetail>> GetAll();

        Task<List<OrderDetail>> GetAllByOrderId(string orderid);

        void UpdateCookRequest(string id,string cook_id,DateTime starttime,DateTime endtime);

        void UpdateStatus(string id,string status);

        void DeleteById(string id);

        OrderDetail GetById(string id);
    }
}
