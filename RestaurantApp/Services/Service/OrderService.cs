using RestaurantApp.Models;
using RestaurantApp.Data;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Service
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext context;
        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void DeleteById(string id)
        {
            var obj = context.Order.Where(x => x.OrderId == id).FirstOrDefault();
            obj.OrderIsDeleted = 1;
            context.Order.Update(obj);
            context.SaveChanges();
        }

        public Order GetById(string id)
        {
            var obj = context.Order.Where(x => x.OrderId == id).FirstOrDefault();
            return (Order)obj;
        }

        public List<Order> GetAll()
        {
            return context.Order.ToList();
        }

        public void Insert(Order order)
        {
            order.OrderId = Guid.NewGuid().ToString();
            order.OrderIsDeleted = 0;
            context.Order.Add(order);
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            var obj = context.Order.Where(x => x.OrderId == order.OrderId).FirstOrDefault();
            obj.OrderDate = order.OrderDate;
            obj.OrderEndtime = order.OrderEndtime;
            obj.OrderStarttime = order.OrderStarttime;
            obj.OrderTotal = order.OrderTotal;
            obj.TableId = order.TableId;
            obj.WaiterId = order.WaiterId;
            context.Order.Update(obj);
            context.SaveChanges();
        }
    }
}
