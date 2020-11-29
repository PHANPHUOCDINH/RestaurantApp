﻿using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services.IService
{
    public interface ITableService
    {
        Task<List<Table>> GetAllTableAsync(bool isactive);

        void UpdateTableStatus(Table table);
    }
}
