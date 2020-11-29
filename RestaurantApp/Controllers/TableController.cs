using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Models;
using RestaurantApp.Route;
using RestaurantApp.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly ITableService service;
        public TableController(ITableService service)
        {
            this.service = service;
        }
        
        [HttpGet(ApiRoute.GetAllTable)]
        public async Task<List<Table>> GetAllTableAsync(bool isactive)
        {
            return await service.GetAllTableAsync(isactive);
        }

        //[HttpGet("test")]
        //public async Task<IActionResult> GetTests()
        //{

        //    ITestService _service;
        //    var service = (ITestService)ServiceProvider.GetService(typeof(ITestService));
        //    return Ok(await _service.GetAllTestAsync());
        //} 
        [HttpPost(ApiRoute.UpdateTableStatus)]
        public void UpdateTableStatus([FromBody] Table table)
        {
            service.UpdateTableStatus(table);
        }
    }
}
