using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            obj.OrderDetailIsDeleted = 1;
            context.OrderDetail.Update(obj);
            context.SaveChanges();
        }

        public List<OrderDetail> GetAll()
        {
            return context.OrderDetail.Where(x => x.OrderDetailIsDeleted == 0).ToList();
        }

        public List<OrderDetail> GetAllByOrderId(string orderid)
        {
            return context.OrderDetail.Where(x=>x.OrderId==orderid && x.OrderDetailIsDeleted==0).ToList();
        }

        public OrderDetail GetById(string id)
        {
            var obj = context.OrderDetail.Where(x => x.OrderDetailId == id ).FirstOrDefault();
            return (OrderDetail)obj;
         
        }

        public void Insert(OrderDetail orderdetail)
        {
           // orderdetail.OrderDetailId = Guid.NewGuid().ToString();
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
