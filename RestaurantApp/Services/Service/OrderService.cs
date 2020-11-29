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
            obj.OrderIsDeleted = true;
            context.Order.Update(obj);
            context.SaveChangesAsync();
        }

        public Order GetById(string id)
        {
            var obj = context.Order.Where(x => x.OrderId == id && !x.OrderIsDeleted).FirstOrDefault();
            return (Order)obj;
        }

        public async Task<List<Order>> GetAll()
        {
            return await context.Order.Where(x=>!x.OrderIsDeleted).ToListAsync();
        }


        public string Insert(Order order)
        {
            order.OrderId = Guid.NewGuid().ToString();
            order.OrderIsDeleted = false;
            context.Order.Add(order);
            context.SaveChangesAsync();
            return order.OrderId;
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
            context.SaveChangesAsync();
        }
    }
}
