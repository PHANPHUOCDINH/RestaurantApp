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
    public class TableService : ITableService
    {
        private readonly ApplicationDbContext context;
        public TableService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Table>> GetAllTableAsync()
        {
            return await context.Table.ToListAsync();
        }

        public void UpdateTableStatus(Table table)
        {
            var obj = context.Table.Where(x => x.TableId == table.TableId).FirstOrDefault();
            obj.TableStatus = table.TableStatus;
            context.Table.Update(obj);
            context.SaveChanges();      
        }

        
    }
}
