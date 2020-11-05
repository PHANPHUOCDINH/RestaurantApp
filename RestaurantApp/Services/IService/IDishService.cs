using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IDishService
    {
        void Insert(Dish dish);

        List<Dish> GetAllDishAsync();

        void Update(Dish dish);

        void DeleteById(string id);

        Dish GetById(string id);
    }
}
