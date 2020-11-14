using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public async Task<List<OrderDetail>> GetAll()
        {
            return await context.OrderDetail.Where(x => !x.OrderDetailIsDeleted).ToListAsync();
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
            // orderdetail.OrderDetailId = Guid.NewGuid().ToString();
            orderdetail.OrderDetailIsDeleted = false;
            context.OrderDetail.Add(orderdetail);
            context.SaveChanges();
        }

        public void UpdateCookRequest(string id,string cook_id, DateTime starttime, DateTime endtime)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == id).FirstOrDefault();
            obj.CookId = cook_id;
            obj.OrderDetailStarttime = starttime;
            obj.OrderDetailEndtime = endtime;
            context.OrderDetail.Update(obj);
            context.SaveChanges();
        }

        public void UpdateStatus(string id,string status)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == id).FirstOrDefault();
            obj.OrderDetailStatus = status;
            context.OrderDetail.Update(obj);
            context.SaveChanges();
        }
    }
}
