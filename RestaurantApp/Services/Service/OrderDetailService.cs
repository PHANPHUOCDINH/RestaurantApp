using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Services.Service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly ApplicationDbContext context;

        public OrderDetailService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteById(string id)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == id).FirstOrDefault();
            obj.OrderDetailIsDeleted = true;
            context.OrderDetail.Update(obj);
            context.SaveChangesAsync();
        }

        public async Task<List<OrderDetail>> GetAll(string cookId)
        {
            return await context.OrderDetail.Where(x => !x.OrderDetailIsDeleted && (x.CookId == cookId || x.CookId == null)).ToListAsync();
        }

        public async Task<List<OrderDetail>> GetAllByOrderId(string orderid)
        {
            return await context.OrderDetail.Where(x => x.OrderId == orderid && !x.OrderDetailIsDeleted).ToListAsync();
        }

        public OrderDetail GetById(string id)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == id && !x.OrderDetailIsDeleted).FirstOrDefault();
            return (OrderDetail)obj;

        }

        public string Insert(OrderDetail orderdetail)
        {
            orderdetail.OrderDetailId = Guid.NewGuid().ToString();
            orderdetail.OrderDetailIsDeleted = false;
            context.OrderDetail.Add(orderdetail);

            context.SaveChangesAsync();
            return orderdetail.OrderDetailId;
        }

        public void Update(OrderDetail obj)
        {
            var detail = context.OrderDetail.Where(x => x.OrderDetailId == obj.OrderDetailId).FirstOrDefault();
            detail.OrderId = obj.OrderId;
            detail.DishId = obj.DishId;
            detail.CookId = obj.CookId;
            detail.OrderDetailStatus = obj.OrderDetailStatus;
            detail.OrderDetailStarttime = obj.OrderDetailStarttime;
            detail.OrderDetailEndtime = obj.OrderDetailEndtime;
            detail.OrderDetailIsDeleted = obj.OrderDetailIsDeleted;
            context.OrderDetail.Update(detail);
            context.SaveChangesAsync();
        }

        public void UpdateCookRequest(OrderDetail od)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == od.OrderDetailId).FirstOrDefault();
            obj.CookId = od.CookId;
            obj.OrderDetailStarttime = od.OrderDetailStarttime;
            obj.OrderDetailEndtime = od.OrderDetailEndtime;
            context.OrderDetail.Update(obj);
            context.SaveChangesAsync();
        }

        public void UpdateStatus(OrderDetail od)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == od.OrderDetailId).FirstOrDefault();
            obj.OrderDetailStatus = od.OrderDetailStatus;
            context.OrderDetail.Update(obj);
            context.SaveChangesAsync();
        }
    }
}
