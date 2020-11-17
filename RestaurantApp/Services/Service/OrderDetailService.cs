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
            context.SaveChanges();
        }

        public async Task<List<OrderDetail>> GetAll(string cookId)
        {
            return await context.OrderDetail.Where(x => !x.OrderDetailIsDeleted && (x.CookId==cookId || x.CookId==null)).ToListAsync();
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

        public void Insert(OrderDetail orderdetail)
        {
            orderdetail.OrderDetailId = Guid.NewGuid().ToString();
            orderdetail.OrderDetailIsDeleted = false;
            context.OrderDetail.Add(orderdetail);
            context.SaveChanges();
        }

        public void UpdateCookRequest(OrderDetail od)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == od.OrderDetailId).FirstOrDefault();
            obj.CookId = od.CookId;
            obj.OrderDetailStarttime = od.OrderDetailStarttime;
            obj.OrderDetailEndtime = od.OrderDetailEndtime;
            context.OrderDetail.Update(obj);
            context.SaveChanges();
        }

        public void UpdateStatus(OrderDetail od)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == od.OrderDetailId).FirstOrDefault();
            obj.OrderDetailStatus = od.OrderDetailStatus;
            context.OrderDetail.Update(obj);
            context.SaveChanges();
        }
    }
}
