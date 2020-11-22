using Microsoft.EntityFrameworkCore;
using RestaurantApp.Data;
using RestaurantApp.Models;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.Service
{
    public class BaoCaoService : IBaoCaoService
    {
        private readonly ApplicationDbContext context;

        public BaoCaoService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Dish>> top10bestseller(int month, int year)
        {
            setDefault();
            List<OrderDetail> lstOD = context.OrderDetail.Where(x => x.OrderDetailStarttime.Value.Month == month && x.OrderDetailStarttime.Value.Year == year && !x.OrderDetailIsDeleted).ToList();
            List<Dish> top10 = context.Dish.Where(x=>x.DishIsActive).ToList();
            foreach(OrderDetail item in lstOD)
            {
                foreach(Dish item1 in top10)
                {
                    if(item.DishId==item1.DishId)
                    {
                        item1.num++;
                    }
                    context.Update(item1);
                }
            }
            context.SaveChanges();
            return await context.Dish.Where(x => x.DishIsActive).OrderByDescending(x => x.num).Take(10).ToListAsync();
        }

        public void setDefault()
        {
                List<Dish> dishes = context.Dish.Where(x=>x.DishIsActive).ToList();
               foreach(Dish d in dishes)
            {
                d.num = 0;
                context.Update(d);
            }
            context.SaveChanges();
        }
    }
}
