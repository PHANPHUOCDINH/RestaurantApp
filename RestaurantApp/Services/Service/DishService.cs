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
    public class DishService : IDishService
    {
        private readonly ApplicationDbContext context;

        public DishService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Dish> GetAllDishAsync()
        {
            return context.Dish.ToList();
        }

        public Dish GetById(string id)
        {
            var obj = context.Dish.Where(x => x.DishId == id && !x.DishIsDeleted).FirstOrDefault();
            return (Dish)obj;
        }

        public void Insert(Dish dish)
        {
            dish.DishIsDeleted = false;
            dish.DishId = Guid.NewGuid().ToString();
            context.Dish.Add(dish);
            context.SaveChanges();
        }
        public void DeleteById(string id)
        {
            var obj = context.Dish.Where(x => x.DishId == id).FirstOrDefault();
            obj.DishIsDeleted = true;
            context.Dish.Update(obj);
            context.SaveChanges();
        }


        //    public Dish GetById(string id)
        //    {
        //        var obj = db.Dishes.Where(x => x.DishId == id).FirstOrDefault();
        //        return (Dish)obj;

        //    }

        //    public void Insert(Dish dish)
        //    {
        //        dish.DishIsDeleted = 0;
        //        db.Dishes.Add(dish);
        //        db.SaveChanges();
        //    }

        public void Update(Dish dish)
        {
            var obj = context.Dish.Where(x => x.DishId == dish.DishId).FirstOrDefault();
            obj.DishDescription = dish.DishDescription;
            obj.DishIsActive = dish.DishIsActive;
            obj.DishName = dish.DishName;
            obj.DishPrice = dish.DishPrice;
            context.Dish.Update(obj);
            context.SaveChanges();
        }

        public async Task<List<Dish>> GetAllAsync()
        {
            return await context.Dish.Where(x => !x.DishIsDeleted).ToListAsync();
        }
    }
}
