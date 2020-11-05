using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IOrderService
    {
        void Insert(Order order);

        List<Order> GetAll();

        Order GetById(string id);

        void Update(Order order);

        void DeleteById(string id);

    }
}
