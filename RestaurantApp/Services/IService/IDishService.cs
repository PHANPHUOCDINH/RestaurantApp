﻿using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface IDishService
    {
        string Insert(Dish dish);

        Task<List<Dish>> GetAllDish(bool isactive);

        void Update(Dish dish);

        void DeleteById(string id);

        Dish GetById(string id);
        
    }
}
