﻿using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IOrderDetailService
    {
        void Insert(OrderDetail orderdetail);

        Task<List<OrderDetail>> GetAll(string cookId);

        Task<List<OrderDetail>> GetAllByOrderId(string orderid);

        void UpdateCookRequest(OrderDetail od);

        void UpdateStatus(OrderDetail od);

        void DeleteById(string id);

        OrderDetail GetById(string id);
    }
}
