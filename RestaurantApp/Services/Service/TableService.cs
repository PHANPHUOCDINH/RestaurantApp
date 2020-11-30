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
        public async Task<List<Table>> GetAllTableAsync(bool isactive)
        {
            if (isactive)
                return await context.Table.Where(x => x.TableIsActive == isactive).ToListAsync();
            else
                return await context.Table.ToListAsync();
        }

        public string Insert(Table table)
        {
            table.TableId = Guid.NewGuid().ToString();
            table.TableIsActive = true;
            context.Table.Add(table);
            context.SaveChangesAsync();
            return table.TableId;
        }

        public void UpdateTable(Table table)
        {
            var obj = context.Table.Where(x => x.TableId == table.TableId).FirstOrDefault();
            obj.TableStatus = table.TableStatus;
            obj.TableIdOrderServing = table.TableIdOrderServing;
            obj.TableName = table.TableName;
            obj.TableIsActive = table.TableIsActive;
            context.Table.Update(obj);
            context.SaveChangesAsync();
        }


    }
}
